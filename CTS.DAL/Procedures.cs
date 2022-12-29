using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CTS.DAL
{
    public static class Procedures
    {

        #region Permissions
        public static string _Select_UserPermissionForPage = "Select_UserPermissionForPage";
        #endregion

        #region Damagerates
        public static string _Save_DamageRates_XML = "Save_DamageRates_XML";
        public static string _Get_AllDamageCodeRates = "Get_AllDamageCodeRates";
        public static string _Delete_DamageCodeRates = "Delete_DamageCodeRates";
        
        
        #endregion
        #region requests
        public static string _Get_ChangRequestsLogs = "Get_ChangRequestsLogs";
        public static string _Get_ContInRequests = "Get_ContInRequests";
        public static string _Cancel_ContInEditRequest = "Cancel_ContInEditRequest";
        public static string _Approve_ContInEditRequest = "Approve_ContInEditRequest";
        public static string _Save_ContainerInEditRequest_XML = "Save_ContainerInEditRequest_XML";
         public static string _Get_ContainerForEditRequest = "Get_ContainerForEditRequest";
        #endregion

        #region department
        public static string _Get_Departments = "Get_Departments";
        #endregion
        #region Usergroup
        public static string _Get_AllUserGroups = "Get_AllUserGroups";
        #endregion

        #region estimate
        public static string _Get_SingleContainer_ForEstimate = "Get_SingleContainer_ForEstimate";
        public static string _Get_NextEstimateNo = "Get_NextEstimateNo";
        public static string _Save_Estimate_XML_NEW = "Save_Estimate_XML_NEW";
        public static string _GetEstimateEntry = "GetEstimateEntry";
        public static string _SaveEstimate_Images = "SaveEstimate_Images";

        public static string _DelEstimate_ImageByName = "DelEstimate_ImageByName";

        public static string _Get_ContainersForEstimate_Image = "Get_ContainersForEstimate_Image";

        public static string _GetEstImages = "GetEstImages";
        public static string _DelEstimate_Image = "DelEstimate_Image";
        public static string _Delete_EstimateImagesFromTmpTable = "Delete_EstimateImagesFromTmpTable";
        public static string _Save_EstimateImagesToTmpTbl = "Save_EstimateImagesToTmpTbl";
        public static string _GetEstimateId = "GetEstimateId";

        
        #endregion

        #region AccountType

        public static string _Get_AccountType = "Get_AccountType";
        #endregion

        #region DamageCode
        public static string _Get_AllDamageCode = "Get_DamageCode";
        public static string _Get_AllRprRepairCodes = "Get_RprRepairCode";
        public static string _Get_RprDamageCode = "Get_RprDamageCode";

        public static string _Update_DamageCodeMaster_Rates = "Update_DamageCodeMaster_Rates";
        public static string _Delete_DamageCode = "damageCodeDelete";
        public static string _Save_DamageCode_XML = "Save_DamageCode_XML";
        #endregion

        #region RepairTypes
        public static string _Get_AllRepairTypes = "Get_AllRepairTypes";
        public static string _DeleteRepairType = "DeleteRepairType";
        public static string _Insert_RepairTypeMaster = "Insert_RepairTypeMaster";
        #endregion

        #region LocationDescription

        public static string _Get_LocationDescriptions = "Get_LocationDescriptions";
        public static string _Delete_LocDescription = "LocDescriptionDelete";
        public static string _Save_Location_Description_Master = "Save_Location_Description_Master_XML";
        #endregion

        #region Location
        public static string _Get_Location = "Get_Location";
        public static string _DeleteLocation = "DeleteLocation";
        public static string _Save_LocationMaster = "Save_Location_Master_XML";
        #endregion

        #region Reports
        public static string _Get_ERO_Data_Export = "Get_ERO_Data_Export";

        public static string _Get_ERO_Data_Empty = "Get_ERO_Data_Empty";
        public static string _Get_DailyReport_CHM = "Get_DailyReport";

        public static string _Get_InoutDetails = "Get_InoutDetails";
        public static string _Get_Container_List = "Get_Container_List";
        public static string _Get_StockHold = "Get_StockHold";
        public static string _Save_Cont_Hold = "Save_Cont_Hold";

        public static string _Get_EstimateRegister = "Get_EstimateRegister";
        #region Reports
        
        #endregion

        #region Bookings
        public static string _Get_Bookings_ForGateOut = "Get_Bookings_ForOut";
        public static string _Get_Remaining_Bookings = "Get_Remaining_bookings";
        #endregion

        #region GateMovements
        public static string _Get_Container = "Get_Container";
        public static string _Save_GATEOUT = "Save_GATEOUT";
        public static string _Save_GATEIN = "Save_GATEIN";
        public static string _GetNewPassNo = "GetNewPassNo";

        public static string _Get_LatestCont = "Get_LatestCont";

        public static string _Get_InDetails = "Get_InDetails";
        public static string _Update_Cont_In_MovementType = "Update_Cont_In_MovementType";
        public static string _Update_Cont_Remarks = "Update_Cont_Remarks";

        public static string _Get_ContainersOnHold = "Get_ContainersOnHold";

        public static string _Save_BULKGATEIN = "Save_BULKGATEIN";

        #endregion


        #region Transporter

        public static string _Save_Transporter_Master_XML_New = "Save_Transporter_Master_XML_New";
        public static string _Get_Transporters = "Get_Transporters";
        public static string _TransporterDelete = "transporterDelete";
        #endregion

        #region Consignee
        public static string _Save_Consignee_Master_XML_New = "Save_Consignee_Master_XML_New";
        public static string _Get_Consignees = "Get_Consignees";
        public static string _ConsigneeDelete = "consigneeDelete";
        #endregion

        #region Vessel

        public static string _Save_Vessel_Master_XML_New = "Save_Vessel_Master_XML_New";
        public static string _Get_Vessels = "Get_Vessels";
        public static string _vesselDelete = "vesselDelete";

        #endregion

        #region Currency

        public static string _Save_Currency_Master_XML_New = "Save_Currency_Master_XML_New";
        public static string _Get_Currencys = "Get_Currencys";
        public static string _Delete_Currency = "Delete_Currency";

        public static string _Get_Company_Customers = "Get_Company_Customers";

        #endregion

        #region Customer

        public static string _Save_Customer_Master_XML_New = "Save_Customer_Master_XML_New";
        public static string _Get_Customer_Details = "Get_Customer_Details";
        public static string _Delete_customer = "Delete_customer";


        #endregion

        #region MainAccount

        public static string _Get_MainAccount_Details = "Get_MainAccount_Details_New";
        public static string _Save_MainAccount_Master_XML_New = "Save_MainAccount_Master_XML_New";
        public static string _Delete_MainAccount = "Delete_MainAccount";

        #endregion
        #region ContainerSize


        public static string _Save_Container_SizeMaster_XML_New = "Save_Container_SizeMaster_XML_New";
        public static string _Get_ContainerSizes = "Get_ContainerSizes";
        public static string _ContSizeDelete = "ContSizeDelete";


        #endregion
        #region ClientGroup
        public static string _Get_ClientGroups = "Get_ClientGroups";

        #endregion

        #region ContainerType

        public static string _Save_Container_TypeMaster_XML_New = "Save_Container_TypeMaster_XML_New";
        public static string _Get_ContainerTypeDetails = "Get_ContainerTypeDetails";
        public static string _ContainerTypeDelete = "ContainerTypeDelete";



        #endregion
        #region Movement

        public static string _Save_Movement_Master_XML_New = "Save_Movement_Master_XML_New";
        public static string _Get_AllMovements = "Get_AllMovements";
        public static string _movementDelete = "movementDelete";


        #endregion

        #region Yard
        public static string _Save_Yard_Master_XML_New = "Save_Yard_Master_XML_New";
        public static string _Get_YardDetails = "Get_YardDetails";
        public static string _yardMasterDelete = "yardMasterDelete";
        public static string _Get_YardsForUser = "Get_YardsForUser";

        #endregion

        #region Branch
        public static string _Save_Branch_Master_XML = "Save_Branch_Master_XML_NEW";
        public static string _Get_Branch_Details = "Get_Branch_Details";
        public static string _Delete_Branch = "Delete_Branch";
        #endregion

        #endregion

        #region Login
        public static string _Authenticate_User = "usp_UserMaster_Authenticate";
        public static string _Get_User = "usp_getUserdetails";

        public static string _Save_User_Master = "Save_User_Master";
        public static string _Get_AllUsers = "Get_AllUsers";
        public static string _Delete_user = "delete_user";

        public static string _SelectGroupsUsers = "SelectGroupsUsers";


        public static string _sp_UserPermissionSaves = "SavePermission";
        public static string _Get_GroupPermissions = "Get_GroupPermissions";

        public static string _Update_UserPassword = "Update_UserPassword";

        public static string _User_Activation = "User_Activation";
        
        
        #endregion



        #region public
        public static string _Get_AllMonths = "Get_AllMonths";

        #endregion

        #region menu
        public static string _Select_AllParentMenu = "Select_AllParentMenu";

        #endregion




    }
}
