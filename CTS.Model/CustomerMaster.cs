using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class CustomerMaster
    {

        public int CustomerID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Add1 { get; set; }
        public string Customer_Add2 { get; set; }
        public string Customer_Add3 { get; set; }
        public string Customer_Add4 { get; set; }
        public Nullable<decimal> Energy { get; set; }
        public Nullable<decimal> Bill_Per { get; set; }
        public Nullable<decimal> Customer_Term { get; set; }
        public string Currency { get; set; }
        public Nullable<bool> Moredays { get; set; }
        public Nullable<bool> Salestax { get; set; }
        public Nullable<bool> Indent { get; set; }
        public Nullable<bool> Repair { get; set; }
        public string Cust_Bill_Type { get; set; }
        public string Cust_code { get; set; }
        public Nullable<decimal> ManHourRate { get; set; }
        public Nullable<bool> TaxExclusive { get; set; }
        public Nullable<int> FreeRentDays { get; set; }
        public Nullable<decimal> Discount_Perc { get; set; }
        public Nullable<bool> Vessel_Wise_Billing { get; set; }
        public Nullable<bool> Incld_Mat_In_ST { get; set; }
        public Nullable<int> Package_Days { get; set; }
        public Nullable<decimal> Package_Amount { get; set; }
        public Nullable<bool> excld_export { get; set; }
        public Nullable<decimal> STax_On_Total { get; set; }
        public Nullable<bool> Incld_Disc_In_STax { get; set; }
        public Nullable<decimal> Reefer_ManHourRate { get; set; }
        public Nullable<bool> OutBilling { get; set; }
        public Nullable<bool> Split_Lump_Frm_RepairBill { get; set; }
        public Nullable<int> State_Code { get; set; }
        public string Pan_No { get; set; }
        public string No_Of_Regs { get; set; }
        public string Def_Digit { get; set; }
        public string CheckSum_Code { get; set; }
        public Nullable<int> currency_id { get; set; }
        public Nullable<bool> Hms_Bill { get; set; }
        public Nullable<bool> Coastal_Bill { get; set; }
        public Nullable<bool> Exclude_Same_DayOut { get; set; }
        public Nullable<bool> Billing { get; set; }
        public Nullable<bool> Deacivate_InCts { get; set; }
        public Nullable<int> Main_Account_Id { get; set; }
        public string Edi_Sender_Iden_UNB { get; set; }
        public string Edi_Recipient_Iden_UNB { get; set; }
        public string Edi_Party_Iden_NAD { get; set; }
        public string Edi_Location_Iden_LOC { get; set; }
        public string Send_EdiTo { get; set; }
        public Nullable<bool> Edi_Automation { get; set; }
        public Nullable<bool> Lessee_Acc { get; set; }
        public Nullable<bool> Leasing_Company { get; set; }
        public string Email_Ids { get; set; }
        public string Edi_Association_Assgin_Code_UNH { get; set; }
        public string Edi_Carrier_Identification_TDT { get; set; }
        public Nullable<bool> Custom_Edi { get; set; }
        public string Ero_Prefix { get; set; }
        public Nullable<long> Last_ERO_No { get; set; }


        public virtual Main_Account_Master Main_Account_Master { get; set; }
        public virtual Currency_Master Currency_Master { get; set; }
    }

    public class CustomerMaster_Datatable
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<CustomerMaster> data = new List<CustomerMaster>();
    }
}
