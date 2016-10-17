using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Infrastructure.Models
{
    [Table("mpats_User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public int OrganisationID { get; set; }
        public string UserIdentifier { get; set; }
        public byte? SalutationID { get; set; }
        public byte? TitleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ApplicationsEmail { get; set; }
        public string Fax { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte UserStatusID { get; set; }
        public int UserRoleID { get; set; }
        public string UserCultureID { get; set; }
        public string WebSite { get; set; }
        public byte? PostingResultsEmail { get; set; }
        public string PostingResultsEmailAddress { get; set; }
        public byte? PostingExpireEmail { get; set; }
        public string PostingExpireEmailAddress { get; set; }
        public byte? PostingResultsDailyEmail { get; set; }
        public string PostingResultsDailyEmailAddress { get; set; }
        public byte? PostingResultsDailyEmailFormat { get; set; }
        public byte? PostingResultsWeeklyEmail { get; set; }
        public string PostingResultsWeeklyEmailAddress { get; set; }
        public byte? PostingResultsWeeklyEmailFormat { get; set; }
        public byte? PostingResultsMonthlyEmail { get; set; }
        public string PostingResultsMonthlyEmailAddress { get; set; }
        public byte? PostingResultsMonthlyEmailFormat { get; set; }
        public DateTime? FirstLoginDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastUpdatePasswordDate { get; set; }
        public string CookieID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeleteUserID { get; set; }
        public string FullName { get; set; }
        public string catsone_subdomain { get; set; }
        public string catsone_transaction_code { get; set; }
        public string PasswordHash { get; set; }
        public string nPasswordHash { get; set; }
        public string UserOrganisationIdentifier { get; set; }
        public string UserOrganisationName { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserAddress3 { get; set; }
        public string UserState { get; set; }
        public string UserCountry { get; set; }
        public string UserPostCode { get; set; }
        public string UserWebSite { get; set; }
        public byte? FeatureFailAllPostings { get; set; }
        public byte? FeatureAuthoriseToPost { get; set; }
        public byte? FeatureCVSearch { get; set; }
        public byte? FeatureCVAggregate { get; set; }
        public byte? FeatureNoAdvertCreate { get; set; }
        public byte? FeatureNoAdvertActions { get; set; }
        public byte? FeatureNoExpressPost { get; set; }
        public byte? FeatureNoQuickPost { get; set; }
        public byte? FeatureNoTemplate { get; set; }
        public Nullable<short> FeatureDefaultAdvertRows { get; set; }
        public Nullable<short> FeatureDefaultCandidateRows { get; set; }
        public Nullable<short> FeatureDefaultOffsetDate { get; set; }
        public byte? FeaturePostFeedSelectionDisplay { get; set; }
        public byte? FeatureCVDatabase { get; set; }
        public string Position { get; set; }
        public Nullable<bool> noTrigger { get; set; }
        public byte? FeatureHidePostings { get; set; }
        public byte? FeatureNoCVSearch { get; set; }
        public byte? FeatureNoEditPost { get; set; }
        public byte? FeatureNoReporting { get; set; }
        public byte? FeaturePerFeedFields { get; set; }
        public byte? FeatureWorkflow { get; set; }
        public int? DefaultOrganisationWorkflowID { get; set; }
        public byte? FeatureNoCandidateActions { get; set; }
        public int? WatchDogsAllowedPerUser { get; set; }
        public string DefaultViewer { get; set; }
        public byte? FeatureAdvertMove { get; set; }
        public byte? FeatureOrganisationMove { get; set; }
        public byte? FeatureUserMove { get; set; }
        public DateTime? PreviousLoginDate { get; set; }
        public byte? FeatureHideCandidatePersonalDetails { get; set; }
        public byte? FeatureHideEqualOpportunities { get; set; }
        public byte? PostingExpirePreEmail { get; set; }
        public string PostingExpirePreEmailAddress { get; set; }
        public byte? FeatureCopyReplyMessages { get; set; }
        public byte? FeatureInterviewAcceptNotify { get; set; }
        public byte? BBDCopySentMessages { get; set; }
        public byte? BBDLiveAdvertEmail { get; set; }
        public byte? BBDExpiringEmail { get; set; }
        public byte? BBDExpiredEmail { get; set; }
        public byte? DailyNewCandidatesEmail { get; set; }
        public byte? BBDInformCandidatesEmail { get; set; }
        public byte? BBDRemovedManuallyEmail { get; set; }
        public byte? FeatureCandidateEdit { get; set; }
        public byte? FeatureCandidateEditName { get; set; }
        public string UserLogoURL { get; set; }
        public int? UserLogoWidth { get; set; }
        public int? UserLogoHeight { get; set; }
        public string TheNeedleAccountKey { get; set; }
        public Nullable<bool> WatchDogsSendNoEmails { get; set; }
        public byte[] UserVersion { get; set; }

        [ForeignKey("UserStatusID")]
        public virtual UserStatus UserStatus { get; set; }

        [ForeignKey("OrganisationID")]
        public virtual Organisation Organisation { get; set; }
    }
}