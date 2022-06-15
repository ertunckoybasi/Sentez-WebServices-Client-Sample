using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sentez_WebServices_Client_Sample.Helpers;
using Sentez_WebServices_Client_Sample.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentez_WebServices_Client_Sample
{
    public partial class frmRestApi : Form
    {
        private string _username = "Sentez";
        private string _password = "1";
        private string _companyCode = "01";
        private string _companyPassword = "01";
        private int _userType = 0;
        private readonly HttpClient _httpClient;
        private readonly ISentezService _sentezService;
        private string _loginToken;

        public frmRestApi(HttpClient httpClient, ISentezService sentezService)
        {
            _sentezService = sentezService;
            _httpClient = httpClient;
            InitializeComponent();
        }

        public async Task<string> GetBoId(string BOName)
        {
            string apiCreateBoUrl = "http://localhost:8080/api/BO/CreateBO";
            string BoId = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BOName"] = BOName, };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiCreateBoUrl, boModel);
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    BoId = json.Data;
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error:{ex.Message}");
            }

            return BoId;
        }

        public async Task<string> GetAll(string BOId)
        {
            string apiLoginUrl = "http://localhost:8080/api/BO/Get";
            string BoId = string.Empty;
            string json = string.Empty;
            var boModel = new Dictionary<string, string>() { ["BOId"] = BOId, };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_loginToken}");

            try
            {
                var uri = QueryHelpers.AddQueryString(apiLoginUrl, boModel);
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic dynJson = JsonConvert.DeserializeObject(result);
                    json = JsonConvert.SerializeObject(dynJson.Data);
                }
                else
                {
                    Debug.WriteLine($"Response Code:{response.StatusCode}");
                }
            }

            catch (Exception ex)
            { Debug.WriteLine($"Error:{ex.Message}"); }

            return json;
        }

        private async void btLogin_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            _username = txtUserCode.Text.Trim();
            _password = txtPassword.Text.Trim();
            _companyCode = txtCompanyCode.Text.Trim();
            _companyPassword = txtCompanyPassword.Text.Trim();

            _loginToken = await _sentezService.Login(_username, _password, _companyCode, _companyPassword, _userType);
            txtLoginToken.Text = _loginToken;

            stopwatch.Stop();
            statusLabel.Text = $"Elapsed Time(MiliSeconds): {stopwatch.ElapsedMilliseconds}";
        }

        private async void btGetAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_loginToken) || cmbBONames.SelectedIndex < 0) return; // Login Ol ve BoNameS Seç!

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            btGetAll.Enabled = false;
            string msBoId = await _sentezService.GetBoId(_loginToken, cmbBONames.Text.Trim(), 0, 0, 0);
            string jsonString = await _sentezService.GetAll(_loginToken, msBoId);
            dynamic json = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, new ExpandoObjectConverter());

            DataTable dataTable = await Helper.ConvertJsonToDatatable(jsonString);
            dgView.DataSource = dataTable;
            btGetAll.Enabled = true;
            stopwatch.Stop();
            statusLabel.Text = $"Elapsed Time(MiliSeconds): {stopwatch.ElapsedMilliseconds}";
        }

        private async void btGetById_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_loginToken) || !int.TryParse(txtInventoryRecId.Text, out _)) return; // Login Ol ve Rakamsal Id Gir!

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            btGetById.Enabled = false;

            string msBoId = await _sentezService.GetBoId(_loginToken, cmbBONames.Text.Trim(), 1, 1, 1);
            string jsonString = await _sentezService.GetById(_loginToken, msBoId, Convert.ToInt32(txtInventoryRecId.Text));
            dynamic json = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, new ExpandoObjectConverter());

            DataTable dataTable = await Helper.ConvertJsonToDatatable(jsonString);
            dgView.DataSource = dataTable;
            btGetById.Enabled = true;
            stopwatch.Stop();
            statusLabel.Text = $"Elapsed Time(MiliSeconds): {stopwatch.ElapsedMilliseconds}";
        }

        private async void btInsertBO_Click(object sender, EventArgs e)
        {
            //Boş bırakılan tablo ve alanlara null değeri atanır 

            Dictionary<string, List<ExpandoObject>> data = new Dictionary<string, List<ExpandoObject>>();

            #region  Tablo oluşturulması
            data.Add("Erp_OrderReceipt", new List<ExpandoObject>()); // Tablo
            data.Add("Erp_OrderReceiptItem", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_OrderReceiptItemVariant", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_InventorySerialTransaction", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_InventoryAllocation", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_OrderReceiptAttachment", new List<ExpandoObject>()); //Tablo ismi
            #endregion

            #region Erp_OrderReceipt
            //// Erp_OrderReceipt tablosu için satırlar eklenir //////////////////////////////////////////////
            var rowOrderReceipt = new ExpandoObject() as IDictionary<string, Object>;
            rowOrderReceipt.Add("RecId", null);
            rowOrderReceipt.Add("CompanyId", 2);
            rowOrderReceipt.Add("WorkplaceCode", null);
            rowOrderReceipt.Add("WorkplaceName", null);
            rowOrderReceipt.Add("ReceiptUpType", null);
            rowOrderReceipt.Add("ReceiptType", 1);
            rowOrderReceipt.Add("ReceiptNo", "001121");
            rowOrderReceipt.Add("ReceiptSubType", 0);
            rowOrderReceipt.Add("ReceiptDate", DateTime.Now);
            rowOrderReceipt.Add("ReceiptTime", "1899-12-30T13:52:49");
            rowOrderReceipt.Add("TermDate", null);
            rowOrderReceipt.Add("DocumentSerialNo", "SD121212");
            rowOrderReceipt.Add("DocumentNo", "D32323");
            rowOrderReceipt.Add("CurrentAccountId", 128569);
            //rowOrderReceipt.Add("CurrentAccountCode", null);// "PM34AQU000000000354");
            //rowOrderReceipt.Add("CurrentAccountName", "MUSTATA PIRPANLAR");
            rowOrderReceipt.Add("CurrentAccountInUse", 1);
            rowOrderReceipt.Add("CurrentAccountForexRateId", 1);
            rowOrderReceipt.Add("CurrentAccountRiskLimit", 1);
            rowOrderReceipt.Add("CurrentAccountIsPotential", null);
            rowOrderReceipt.Add("CurrentAccountIsEInvoice", 1);
            rowOrderReceipt.Add("CurrentAccountEInvoiceScenario", null);
            rowOrderReceipt.Add("CurrentAccountIsBlackList", null);
            rowOrderReceipt.Add("CurrentAccountIsEDespatch", null);
            rowOrderReceipt.Add("AddressId", null);
            rowOrderReceipt.Add("AddressCode", null);
            rowOrderReceipt.Add("AddressName", null);
            rowOrderReceipt.Add("AddressInUse", null);
            rowOrderReceipt.Add("ShippingAddressId", null);
            rowOrderReceipt.Add("ShippingAddressCode", null);
            rowOrderReceipt.Add("ShippingAddressName", null);
            rowOrderReceipt.Add("ShippingAddressInUse", null);
            rowOrderReceipt.Add("WarehouseId", 2);
            rowOrderReceipt.Add("WarehouseCode", "01-İKUD");
            //rowOrderReceipt.Add("WarehouseName", "Depo");
            //rowOrderReceipt.Add("WarehouseInUse", 1);
            //rowOrderReceipt.Add("WarehouseStartDate", null);
            //rowOrderReceipt.Add("WarehouseEndDate", null);
            //rowOrderReceipt.Add("WarehouseIsLocked", null);
            rowOrderReceipt.Add("CostCenterId", null);
            //rowOrderReceipt.Add("CostCenterCode", null);
            //rowOrderReceipt.Add("CostCenterName", null);
            //rowOrderReceipt.Add("CostCenterInUse", null);
            rowOrderReceipt.Add("DealerId", null);
            //rowOrderReceipt.Add("DealerCode", null);
            //rowOrderReceipt.Add("DealerName", null);
            //rowOrderReceipt.Add("DealerInUse", null);
            rowOrderReceipt.Add("CustomerId", null);
            //rowOrderReceipt.Add("CustomerCode", null);
            //rowOrderReceipt.Add("CustomerName", null);
            //rowOrderReceipt.Add("CustomerInUse", null);
            rowOrderReceipt.Add("CustomerAddressId", null);
            rowOrderReceipt.Add("CustomerAddressCode", null);
            rowOrderReceipt.Add("CustomerAddressName", null);
            rowOrderReceipt.Add("CustomerAddressInUse", null);
            rowOrderReceipt.Add("PaymentPlanId", null);
            rowOrderReceipt.Add("PaymentPlanCode", null);
            rowOrderReceipt.Add("ShipToCurrentAccountId", null);
            rowOrderReceipt.Add("ShipCurrentAccountCode", null);
            rowOrderReceipt.Add("ShipCurrentAccountName", null);
            rowOrderReceipt.Add("ShipCurrentAccountInUse", null);
            rowOrderReceipt.Add("ShipToAddressId", null);
            rowOrderReceipt.Add("ShipAddressCode", null);
            rowOrderReceipt.Add("ShipAddressName", null);
            rowOrderReceipt.Add("ShipAddressInUse", null);
            rowOrderReceipt.Add("CustomerOrderNo", null);
            rowOrderReceipt.Add("SpecialCode", null);
            rowOrderReceipt.Add("AccessCode", null);
            rowOrderReceipt.Add("ProjectId", null);
            rowOrderReceipt.Add("ProjectCode", null);
            rowOrderReceipt.Add("ProjectName", null);
            rowOrderReceipt.Add("ProjectInUse", null);
            rowOrderReceipt.Add("ProjectStartDate", null);
            rowOrderReceipt.Add("ProjectEndDate", null);
            rowOrderReceipt.Add("EmployeeId", null);
            //rowOrderReceipt.Add("EmployeeCode", "000003");
            //rowOrderReceipt.Add("EmployeeName", null);
            //rowOrderReceipt.Add("EmployeeInUse", true);
            rowOrderReceipt.Add("ContactId", null);
            rowOrderReceipt.Add("CurrentAccountContactName", null);
            rowOrderReceipt.Add("CurrentAccountContactSurname", null);
            rowOrderReceipt.Add("CurrentAccountContactInUse", null);
            rowOrderReceipt.Add("CashId", null);
            rowOrderReceipt.Add("CashCode", null);
            rowOrderReceipt.Add("CashName", null);
            rowOrderReceipt.Add("TransporterId", null);
            rowOrderReceipt.Add("TransporterCode", null);
            rowOrderReceipt.Add("TransporterName", null);
            rowOrderReceipt.Add("TransporterInUse", null);
            rowOrderReceipt.Add("Explanation", null);
            rowOrderReceipt.Add("GpsXCoordinate", null);
            rowOrderReceipt.Add("GpsYCoordinate", null);
            rowOrderReceipt.Add("IsTaxExempted", false);
            rowOrderReceipt.Add("ShipmentType", 1);
            rowOrderReceipt.Add("SubTotal", null);
            rowOrderReceipt.Add("SubTotalVatIncluded", null);
            rowOrderReceipt.Add("VatAmount", null);
            rowOrderReceipt.Add("VatAmountAccommodation", null);
            rowOrderReceipt.Add("ExciseTaxAmount", null);
            rowOrderReceipt.Add("CommunicationTaxAmount", null);
            rowOrderReceipt.Add("DistributedDiscountsTotal", null);
            rowOrderReceipt.Add("DistributedDiscountsTotalVatIncluded", null);
            rowOrderReceipt.Add("DiscountsTotal", null);
            rowOrderReceipt.Add("DiscountsTotalGross", null);
            rowOrderReceipt.Add("DiscountsTotalVatIncluded", null);
            rowOrderReceipt.Add("DistributedExpensesTotal", null);
            rowOrderReceipt.Add("ExpensesTotal", null);
            rowOrderReceipt.Add("GrandTotal", 100);
            rowOrderReceipt.Add("ForexId", null);
            rowOrderReceipt.Add("ForexCode", null);
            rowOrderReceipt.Add("ForexName", null);
            rowOrderReceipt.Add("ForexRate", 1);
            rowOrderReceipt.Add("SubTotalForex", null);
            rowOrderReceipt.Add("SubTotalVatIncludedForex", null);
            rowOrderReceipt.Add("VatAmountForex", null);
            rowOrderReceipt.Add("VatAmountAccommodationForex", null);
            rowOrderReceipt.Add("ExciseTaxAmountForex", null);
            rowOrderReceipt.Add("CommunicationTaxAmountForex", null);
            rowOrderReceipt.Add("DistributedDiscountsTotalForex", null);
            rowOrderReceipt.Add("DistributedDiscountsTotalVatIncludedForex", null);
            rowOrderReceipt.Add("DiscountsTotalForex", null);
            rowOrderReceipt.Add("DiscountsTotalGrossForex", null);
            rowOrderReceipt.Add("DiscountsTotalVatIncludedForex", null);
            rowOrderReceipt.Add("DistributedExpensesTotalForex", null);
            rowOrderReceipt.Add("ExpensesTotalForex", null);
            rowOrderReceipt.Add("GrandTotalForex", null);
            rowOrderReceipt.Add("SubTotalCurrency2", null);
            rowOrderReceipt.Add("ExpensesTotalCurrency2", null);
            rowOrderReceipt.Add("DiscountsTotalCurrency2", null);
            rowOrderReceipt.Add("VatAmountCurrency2", null);
            rowOrderReceipt.Add("GrandTotalCurrency2", null);
            rowOrderReceipt.Add("WithholdingAmount1Currency2", null);
            rowOrderReceipt.Add("WithholdingAmount2Currency2", null);
            rowOrderReceipt.Add("SubTotalCurrency3", null);
            rowOrderReceipt.Add("ExpensesTotalCurrency3", null);
            rowOrderReceipt.Add("DiscountsTotalCurrency3", null);
            rowOrderReceipt.Add("VatAmountCurrency3", null);
            rowOrderReceipt.Add("GrandTotalCurrency3", null);
            rowOrderReceipt.Add("WithholdingAmount1Currency3", null);
            rowOrderReceipt.Add("WithholdingAmount2Currency3", null);
            rowOrderReceipt.Add("PosReceiptId", null);
            rowOrderReceipt.Add("WorkOrderReceiptId", null);
            rowOrderReceipt.Add("GLReceiptId", null);
            rowOrderReceipt.Add("CurrentAccountReceiptId", null);
            rowOrderReceipt.Add("CustomerTransactionId", null);
            rowOrderReceipt.Add("CustomerTransactionDocumentNo", null);
            rowOrderReceipt.Add("VehicleId", null);
            rowOrderReceipt.Add("VehicleCode", null);
            rowOrderReceipt.Add("VehicleName", null);
            rowOrderReceipt.Add("VehiclePlateNumber", null);
            rowOrderReceipt.Add("IsSample", null);
            rowOrderReceipt.Add("IsEximReceipt", false);

            rowOrderReceipt.Add("IsPrinted", null);
            rowOrderReceipt.Add("PageCount", null);
            rowOrderReceipt.Add("IsChecked", null);
            rowOrderReceipt.Add("IsForexReceipt", false);

            //rowOrderReceipt.Add("IsApproved", null);
            //rowOrderReceipt.Add("ApprovedAt", null);
            //rowOrderReceipt.Add("ApprovedBy", null);
            //rowOrderReceipt.Add("ApprovedExplanation", null);
            //rowOrderReceipt.Add("IsLocked", null);
            //rowOrderReceipt.Add("LockedAt", null);
            //rowOrderReceipt.Add("LockedBy", null);
            //rowOrderReceipt.Add("ControlCode", 0);

            //rowOrderReceipt.Add("IsClosed", null);
            //rowOrderReceipt.Add("ClosedAt", null);
            //rowOrderReceipt.Add("ClosedBy", null);
            //rowOrderReceipt.Add("ClosedExplanation", null);
            //rowOrderReceipt.Add("IsCancelled", false);

            //rowOrderReceipt.Add("CancelledAt", null);
            //rowOrderReceipt.Add("CancelledBy", null);
            //rowOrderReceipt.Add("CancelledExplanation", null);
            //rowOrderReceipt.Add("InsertedAt", null);
            //rowOrderReceipt.Add("InsertedBy", null);
            //rowOrderReceipt.Add("UpdatedAt", null);
            //rowOrderReceipt.Add("UpdatedBy", null);
            //rowOrderReceipt.Add("IsDeleted", false);

            //rowOrderReceipt.Add("DeletedAt", null);
            //rowOrderReceipt.Add("DeletedBy", null);
            rowOrderReceipt.Add("UniqueId", null);
            //rowOrderReceipt.Add("ECMOrderNo", "323232");
            //rowOrderReceipt.Add("EArchivesPaymentType", null);
            // rowOrderReceipt.Add("EArchivesWebAddress", null);
            //rowOrderReceipt.Add("EArchivesSendDate", null);
            //rowOrderReceipt.Add("IsETrade", null);
            //rowOrderReceipt.Add("PaymentToCurrentAccountId", null);
            //rowOrderReceipt.Add("EArchivesPaymentTypeOtherExp", null);
            //rowOrderReceipt.Add("UD_MngCargoInvoiceNo", null);
            //rowOrderReceipt.Add("UD_MngCargoBarcode", null);
            //rowOrderReceipt.Add("UD_MngCargoStatus", null);
            //rowOrderReceipt.Add("UD_MngCargoStatusNote", null);
            //rowOrderReceipt.Add("UD_MngCargoReferenceId", null);
            //rowOrderReceipt.Add("UD_MngCargoShipmentId", null);
            //rowOrderReceipt.Add("UD_CargoInvoiceNo", null);
            //rowOrderReceipt.Add("UD_CargoCurrentAccountCode", null);
            //rowOrderReceipt.Add("UD_Explanation", null);
            //rowOrderReceipt.Add("CurrentAccountCalculateRisk", 0);
            //rowOrderReceipt.Add("CurrentAccountCalculateRemainingRisk", 0);
            //rowOrderReceipt.Add("CurrentAccountRiskType", 0);
            //rowOrderReceipt.Add("CurrentAccountRiskTypeCheque", false);
            //rowOrderReceipt.Add("CurrentAccountRiskTypeEndorsmentCheque", false);
            //rowOrderReceipt.Add("CurrentAccountRiskOver", 0);
            //rowOrderReceipt.Add("CurrentAccountChequeRiskFactor", 0);
            //rowOrderReceipt.Add("CurrentAccountNoteRiskFactor", 0);
            //rowOrderReceipt.Add("CurrentAccountIsForex", null);
            //rowOrderReceipt.Add("CurrentAccountForexId", null);
            //rowOrderReceipt.Add("CurrentAccountRiskLevelColor", "0");
            //rowOrderReceipt.Add("TotalQuantity", 0);
            // rowOrderReceipt.Add("ReceiptItemCount", 0);
            // rowOrderReceipt.Add("TotalReceivedQuantity", 0);
            //rowOrderReceipt.Add("TotalRemaindQuantity", 0);
            // rowOrderReceipt.Add("TermDay", 0);
            #endregion

            #region Erp_OrderReceipt
            var rowOrderReceiptItem = new ExpandoObject() as IDictionary<string, Object>;
            rowOrderReceiptItem.Add("RecId", null);
            rowOrderReceiptItem.Add("ReceiptType", 2);
            rowOrderReceiptItem.Add("InventoryId", 12870);
            rowOrderReceiptItem.Add("ItemType", 1);
            //rowOrderReceiptItem.Add("ItemOrderNo", 2);

            // rowOrderReceiptItem.Add("InventoryCode", "2830");
            rowOrderReceiptItem.Add("Quantity", (decimal)1);
            rowOrderReceiptItem.Add("NetQuantity", 1);
            rowOrderReceiptItem.Add("UnitPrice", 2);
            rowOrderReceiptItem.Add("UnitId", 1);
            rowOrderReceiptItem.Add("IsApproved", 1);
            #endregion

            data["Erp_OrderReceipt"].Add((ExpandoObject)rowOrderReceipt);
            data["Erp_OrderReceiptItem"].Add((ExpandoObject)rowOrderReceiptItem);

            string response = await _sentezService.PostBO(_loginToken, "OrderReceiptBO", data);
        }
        private async void btUpdateRecord_Click(object sender, EventArgs e)
        {
            //Boş bırakılan tablo ve alanlara null değeri atanır 
            Dictionary<string, List<ExpandoObject>> data = new Dictionary<string, List<ExpandoObject>>();

            #region  Tablo oluşturulması
            data.Add("Erp_OrderReceipt", new List<ExpandoObject>()); // Tablo
            data.Add("Erp_OrderReceiptItem", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_OrderReceiptItemVariant", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_InventorySerialTransaction", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_InventoryAllocation", new List<ExpandoObject>()); //Tablo ismi
            //data.Add("Erp_OrderReceiptAttachment", new List<ExpandoObject>()); //Tablo ismi
            #endregion

            #region Erp_OrderReceipt
            //// Erp_OrderReceipt tablosu için satırlar eklenir //////////////////////////////////////////////
            var rowOrderReceipt = new ExpandoObject() as IDictionary<string, Object>;
            rowOrderReceipt.Add("RecId", null);
            rowOrderReceipt.Add("CompanyId", 2);
            //rowOrderReceipt.Add("WorkplaceCode","01");
            //rowOrderReceipt.Add("WorkplaceName", null);
            rowOrderReceipt.Add("ReceiptUpType", null);
            rowOrderReceipt.Add("ReceiptType", 1);
            rowOrderReceipt.Add("ReceiptNo", "001121222");
            rowOrderReceipt.Add("ReceiptSubType", 0);
            rowOrderReceipt.Add("ReceiptDate", DateTime.Now);
            rowOrderReceipt.Add("ReceiptTime", "1899-12-30T13:52:49");
            rowOrderReceipt.Add("TermDate", null);
            rowOrderReceipt.Add("DocumentSerialNo", "SD121212");
            rowOrderReceipt.Add("DocumentNo", "D32323");
            rowOrderReceipt.Add("CurrentAccountId", 128569);
            //rowOrderReceipt.Add("CurrentAccountCode", null);// "PM34AQU000000000354");
            //rowOrderReceipt.Add("CurrentAccountName", "MUSTATA PIRPANLAR");
            //rowOrderReceipt.Add("CurrentAccountInUse", 1);
            //rowOrderReceipt.Add("CurrentAccountForexRateId", 1);
            //rowOrderReceipt.Add("CurrentAccountRiskLimit", 1);
            //rowOrderReceipt.Add("CurrentAccountIsPotential", null);
            //rowOrderReceipt.Add("CurrentAccountIsEInvoice", 1);
            //rowOrderReceipt.Add("CurrentAccountEInvoiceScenario", null);
            //rowOrderReceipt.Add("CurrentAccountIsBlackList", null);
            //rowOrderReceipt.Add("CurrentAccountIsEDespatch", null);
            //rowOrderReceipt.Add("AddressId", null);
            //rowOrderReceipt.Add("AddressCode", null);
            //rowOrderReceipt.Add("AddressName", null);
            //rowOrderReceipt.Add("AddressInUse", null);
            //rowOrderReceipt.Add("ShippingAddressId", null);
            //rowOrderReceipt.Add("ShippingAddressCode", null);
            //rowOrderReceipt.Add("ShippingAddressName", null);
            //rowOrderReceipt.Add("ShippingAddressInUse", null);
            rowOrderReceipt.Add("WarehouseId", 2);
            //rowOrderReceipt.Add("WarehouseCode", "01-İKUD");
            //rowOrderReceipt.Add("WarehouseName", "Depo");
            //rowOrderReceipt.Add("WarehouseInUse", 1);
            //rowOrderReceipt.Add("WarehouseStartDate", null);
            //rowOrderReceipt.Add("WarehouseEndDate", null);
            //rowOrderReceipt.Add("WarehouseIsLocked", null);
            rowOrderReceipt.Add("CostCenterId", null);
            //rowOrderReceipt.Add("CostCenterCode", null);
            //rowOrderReceipt.Add("CostCenterName", null);
            //rowOrderReceipt.Add("CostCenterInUse", null);
            rowOrderReceipt.Add("DealerId", null);
            //rowOrderReceipt.Add("DealerCode", null);
            //rowOrderReceipt.Add("DealerName", null);
            //rowOrderReceipt.Add("DealerInUse", null);
            rowOrderReceipt.Add("CustomerId", null);
            //rowOrderReceipt.Add("CustomerCode", null);
            //rowOrderReceipt.Add("CustomerName", null);
            //rowOrderReceipt.Add("CustomerInUse", null);
            //rowOrderReceipt.Add("CustomerAddressId", null);
            //rowOrderReceipt.Add("CustomerAddressCode", null);
            //rowOrderReceipt.Add("CustomerAddressName", null);
            //rowOrderReceipt.Add("CustomerAddressInUse", null);
            //rowOrderReceipt.Add("PaymentPlanId", null);
            //rowOrderReceipt.Add("PaymentPlanCode", null);
            //rowOrderReceipt.Add("ShipToCurrentAccountId", null);
            //rowOrderReceipt.Add("ShipCurrentAccountCode", null);
            //rowOrderReceipt.Add("ShipCurrentAccountName", null);
            //rowOrderReceipt.Add("ShipCurrentAccountInUse", null);
            //rowOrderReceipt.Add("ShipToAddressId", null);
            //rowOrderReceipt.Add("ShipAddressCode", null);
            //rowOrderReceipt.Add("ShipAddressName", null);
            //rowOrderReceipt.Add("ShipAddressInUse", null);
            //rowOrderReceipt.Add("CustomerOrderNo", null);
            //rowOrderReceipt.Add("SpecialCode", null);
            //rowOrderReceipt.Add("AccessCode", null);
            //rowOrderReceipt.Add("ProjectId", null);
            //rowOrderReceipt.Add("ProjectCode", null);
            //rowOrderReceipt.Add("ProjectName", null);
            //rowOrderReceipt.Add("ProjectInUse", null);
            //rowOrderReceipt.Add("ProjectStartDate", null);
            //rowOrderReceipt.Add("ProjectEndDate", null);
            //rowOrderReceipt.Add("EmployeeId", null);
            //rowOrderReceipt.Add("EmployeeCode", "000003");
            //rowOrderReceipt.Add("EmployeeName", null);
            //rowOrderReceipt.Add("EmployeeInUse", true);
            //rowOrderReceipt.Add("ContactId", null);
            //rowOrderReceipt.Add("CurrentAccountContactName", null);
            //rowOrderReceipt.Add("CurrentAccountContactSurname", null);
            //rowOrderReceipt.Add("CurrentAccountContactInUse", null);
            //rowOrderReceipt.Add("CashId", null);
            //rowOrderReceipt.Add("CashCode", null);
            //rowOrderReceipt.Add("CashName", null);
            //rowOrderReceipt.Add("TransporterId", null);
            //rowOrderReceipt.Add("TransporterCode", null);
            //rowOrderReceipt.Add("TransporterName", null);
            //rowOrderReceipt.Add("TransporterInUse", null);
            //rowOrderReceipt.Add("Explanation", null);
            //rowOrderReceipt.Add("GpsXCoordinate", null);
            //rowOrderReceipt.Add("GpsYCoordinate", null);
            //rowOrderReceipt.Add("IsTaxExempted", false);
            //rowOrderReceipt.Add("ShipmentType", 1);
            //rowOrderReceipt.Add("SubTotal", null);
            //rowOrderReceipt.Add("SubTotalVatIncluded", null);
            //rowOrderReceipt.Add("VatAmount", null);
            //rowOrderReceipt.Add("VatAmountAccommodation", null);
            //rowOrderReceipt.Add("ExciseTaxAmount", null);
            //rowOrderReceipt.Add("CommunicationTaxAmount", null);
            //rowOrderReceipt.Add("DistributedDiscountsTotal", null);
            //rowOrderReceipt.Add("DistributedDiscountsTotalVatIncluded", null);
            rowOrderReceipt.Add("DiscountsTotal", null);
            rowOrderReceipt.Add("DiscountsTotalGross", null);
            rowOrderReceipt.Add("DiscountsTotalVatIncluded", null);
            rowOrderReceipt.Add("DistributedExpensesTotal", null);
            rowOrderReceipt.Add("ExpensesTotal", null);
            rowOrderReceipt.Add("GrandTotal", 100);
            rowOrderReceipt.Add("ForexId", null);
            //rowOrderReceipt.Add("ForexCode", null);
            //rowOrderReceipt.Add("ForexName", null);
            rowOrderReceipt.Add("ForexRate", 1);
            rowOrderReceipt.Add("SubTotalForex", null);
            rowOrderReceipt.Add("SubTotalVatIncludedForex", null);
            rowOrderReceipt.Add("VatAmountForex", null);
            rowOrderReceipt.Add("VatAmountAccommodationForex", null);
            rowOrderReceipt.Add("ExciseTaxAmountForex", null);
            rowOrderReceipt.Add("CommunicationTaxAmountForex", null);
            rowOrderReceipt.Add("DistributedDiscountsTotalForex", null);
            rowOrderReceipt.Add("DistributedDiscountsTotalVatIncludedForex", null);
            rowOrderReceipt.Add("DiscountsTotalForex", null);
            rowOrderReceipt.Add("DiscountsTotalGrossForex", null);
            rowOrderReceipt.Add("DiscountsTotalVatIncludedForex", null);
            rowOrderReceipt.Add("DistributedExpensesTotalForex", null);
            rowOrderReceipt.Add("ExpensesTotalForex", null);
            rowOrderReceipt.Add("GrandTotalForex", null);
            rowOrderReceipt.Add("SubTotalCurrency2", null);
            rowOrderReceipt.Add("ExpensesTotalCurrency2", null);
            rowOrderReceipt.Add("DiscountsTotalCurrency2", null);
            rowOrderReceipt.Add("VatAmountCurrency2", null);
            rowOrderReceipt.Add("GrandTotalCurrency2", null);
            rowOrderReceipt.Add("WithholdingAmount1Currency2", null);
            rowOrderReceipt.Add("WithholdingAmount2Currency2", null);
            rowOrderReceipt.Add("SubTotalCurrency3", null);
            rowOrderReceipt.Add("ExpensesTotalCurrency3", null);
            rowOrderReceipt.Add("DiscountsTotalCurrency3", null);
            rowOrderReceipt.Add("VatAmountCurrency3", null);
            rowOrderReceipt.Add("GrandTotalCurrency3", null);
            rowOrderReceipt.Add("WithholdingAmount1Currency3", null);
            rowOrderReceipt.Add("WithholdingAmount2Currency3", null);
            rowOrderReceipt.Add("PosReceiptId", null);
            rowOrderReceipt.Add("WorkOrderReceiptId", null);
            rowOrderReceipt.Add("GLReceiptId", null);
            rowOrderReceipt.Add("CurrentAccountReceiptId", null);
            rowOrderReceipt.Add("CustomerTransactionId", null);
            //rowOrderReceipt.Add("CustomerTransactionDocumentNo", null);
            rowOrderReceipt.Add("VehicleId", null);
            //rowOrderReceipt.Add("VehicleCode", null);
            //rowOrderReceipt.Add("VehicleName", null);
            //rowOrderReceipt.Add("VehiclePlateNumber", null);
            rowOrderReceipt.Add("IsSample", null);
            rowOrderReceipt.Add("IsEximReceipt", false);

            rowOrderReceipt.Add("IsPrinted", null);
            rowOrderReceipt.Add("PageCount", null);
            rowOrderReceipt.Add("IsChecked", null);
            rowOrderReceipt.Add("IsForexReceipt", false);

            //rowOrderReceipt.Add("IsApproved", null);
            //rowOrderReceipt.Add("ApprovedAt", null);
            //rowOrderReceipt.Add("ApprovedBy", null);
            //rowOrderReceipt.Add("ApprovedExplanation", null);
            //rowOrderReceipt.Add("IsLocked", null);
            //rowOrderReceipt.Add("LockedAt", null);
            //rowOrderReceipt.Add("LockedBy", null);
            //rowOrderReceipt.Add("ControlCode", 0);

            //rowOrderReceipt.Add("IsClosed", null);
            //rowOrderReceipt.Add("ClosedAt", null);
            //rowOrderReceipt.Add("ClosedBy", null);
            //rowOrderReceipt.Add("ClosedExplanation", null);
            //rowOrderReceipt.Add("IsCancelled", false);

            //rowOrderReceipt.Add("CancelledAt", null);
            //rowOrderReceipt.Add("CancelledBy", null);
            //rowOrderReceipt.Add("CancelledExplanation", null);
            //rowOrderReceipt.Add("InsertedAt", null);
            //rowOrderReceipt.Add("InsertedBy", null);
            //rowOrderReceipt.Add("UpdatedAt", null);
            //rowOrderReceipt.Add("UpdatedBy", null);
            //rowOrderReceipt.Add("IsDeleted", false);

            //rowOrderReceipt.Add("DeletedAt", null);
            //rowOrderReceipt.Add("DeletedBy", null);
            rowOrderReceipt.Add("UniqueId", null);
            //rowOrderReceipt.Add("ECMOrderNo", "323232");
            //rowOrderReceipt.Add("EArchivesPaymentType", null);
            // rowOrderReceipt.Add("EArchivesWebAddress", null);
            //rowOrderReceipt.Add("EArchivesSendDate", null);
            //rowOrderReceipt.Add("IsETrade", null);
            //rowOrderReceipt.Add("PaymentToCurrentAccountId", null);
            //rowOrderReceipt.Add("EArchivesPaymentTypeOtherExp", null);
            //rowOrderReceipt.Add("UD_MngCargoInvoiceNo", null);
            //rowOrderReceipt.Add("UD_MngCargoBarcode", null);
            //rowOrderReceipt.Add("UD_MngCargoStatus", null);
            //rowOrderReceipt.Add("UD_MngCargoStatusNote", null);
            //rowOrderReceipt.Add("UD_MngCargoReferenceId", null);
            //rowOrderReceipt.Add("UD_MngCargoShipmentId", null);
            //rowOrderReceipt.Add("UD_CargoInvoiceNo", null);
            //rowOrderReceipt.Add("UD_CargoCurrentAccountCode", null);
            //rowOrderReceipt.Add("UD_Explanation", null);
            //rowOrderReceipt.Add("CurrentAccountCalculateRisk", 0);
            //rowOrderReceipt.Add("CurrentAccountCalculateRemainingRisk", 0);
            //rowOrderReceipt.Add("CurrentAccountRiskType", 0);
            //rowOrderReceipt.Add("CurrentAccountRiskTypeCheque", false);
            //rowOrderReceipt.Add("CurrentAccountRiskTypeEndorsmentCheque", false);
            //rowOrderReceipt.Add("CurrentAccountRiskOver", 0);
            //rowOrderReceipt.Add("CurrentAccountChequeRiskFactor", 0);
            //rowOrderReceipt.Add("CurrentAccountNoteRiskFactor", 0);
            //rowOrderReceipt.Add("CurrentAccountIsForex", null);
            //rowOrderReceipt.Add("CurrentAccountForexId", null);
            //rowOrderReceipt.Add("CurrentAccountRiskLevelColor", "0");
            //rowOrderReceipt.Add("TotalQuantity", 0);
            // rowOrderReceipt.Add("ReceiptItemCount", 0);
            // rowOrderReceipt.Add("TotalReceivedQuantity", 0);
            //rowOrderReceipt.Add("TotalRemaindQuantity", 0);
            // rowOrderReceipt.Add("TermDay", 0);
            #endregion

            #region Erp_OrderReceipt
            var rowOrderReceiptItem = new ExpandoObject() as IDictionary<string, Object>;
            rowOrderReceiptItem.Add("RecId", null);
            rowOrderReceiptItem.Add("ReceiptType", 2);
            rowOrderReceiptItem.Add("InventoryId", 12870);
            rowOrderReceiptItem.Add("ItemType", 1);
            //rowOrderReceiptItem.Add("ItemOrderNo", 2);

            // rowOrderReceiptItem.Add("InventoryCode", "2830");
            rowOrderReceiptItem.Add("Quantity", 2);
            rowOrderReceiptItem.Add("NetQuantity", 2);
            rowOrderReceiptItem.Add("UnitPrice", 2);
            rowOrderReceiptItem.Add("UnitId", 1);
            rowOrderReceiptItem.Add("IsApproved", 1);
            #endregion

            data["Erp_OrderReceipt"].Add((ExpandoObject)rowOrderReceipt);
            data["Erp_OrderReceiptItem"].Add((ExpandoObject)rowOrderReceiptItem);

            string response = await _sentezService.UpdateBO(_loginToken, "OrderReceiptBO", 82165, data);
        }

        private async void btExecuteQuery_GetProductWithVariants_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_loginToken) || string.IsNullOrEmpty(txtQuery.Text)) return; // Login Ol ve Query Yaz!

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            btExecuteQuery_GetProductWithVariants.Enabled = false;


            string jsonString = await _sentezService.ExecuteQuery(_loginToken, txtQuery.Text);
            dynamic json = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, new ExpandoObjectConverter());

            DataTable dataTable = await Helper.ConvertJsonToDatatable(jsonString);
            dgViewExecuteQuery.DataSource = dataTable;
            btExecuteQuery_GetProductWithVariants.Enabled = true;
            stopwatch.Stop();
            statusLabel.Text = $"Elapsed Time(MiliSeconds): {stopwatch.ElapsedMilliseconds}";
        }

       
    }

}




