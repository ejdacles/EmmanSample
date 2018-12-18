﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    internal partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
            ChallengeTemplateModels = Set<ChallengeTemplateModel>();
            ControlPanelModels = Set<ControlPanelModel>();
            PhaseModels = Set<PhaseModel>();
            StimulationSettingsModels = Set<StimulationSettingsModel>();
            WorkflowConfigurations = Set<WorkflowConfiguration>();
            WorkflowStepConfigurations = Set<WorkflowStepConfiguration>();
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Study> Studies { get; set; }
        public virtual DbSet<UserSetting> UserSettings { get; set; }
        public virtual DbSet<WorkflowStepResult> WorkflowStepResults { get; set; }
        public virtual DbSet<Question_Choice> Question_Choice { get; set; }
        public virtual DbSet<SQuestion> SQuestions { get; set; }
        public virtual DbSet<SQuestionnaire> SQuestionnaires { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Questionnaire_Question> Questionnaire_Question { get; set; }
        public virtual DbSet<ChoiceGroup> ChoiceGroups { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<GeneratedReportComponent> GeneratedReportComponents { get; set; }
        public virtual DbSet<ReportComponent> ReportComponents { get; set; }
        internal virtual DbSet<ChallengeTemplateModel> ChallengeTemplateModels { get; set; }
        internal virtual DbSet<ControlPanelModel> ControlPanelModels { get; set; }
        internal virtual DbSet<PhaseModel> PhaseModels { get; set; }
        internal virtual DbSet<StimulationSettingsModel> StimulationSettingsModels { get; set; }
        internal virtual DbSet<WorkflowConfiguration> WorkflowConfigurations { get; set; }
        internal virtual DbSet<WorkflowStepConfiguration> WorkflowStepConfigurations { get; set; }
        public virtual DbSet<Formula> Formulas { get; set; }
        public virtual DbSet<QuestionnaireFormula> QuestionnaireFormulas { get; set; }
        public virtual DbSet<QuestionnaireScore> QuestionnaireScores { get; set; }
        public virtual DbSet<BaseDevice> BaseDevices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AppSecurity> AppSecurities { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<UsedService> UsedServices { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role_Types> Role_Types { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ImageResult> ImageResults { get; set; }
        public virtual DbSet<PatientsGroup> PatientsGroups { get; set; }
        public virtual DbSet<Question_SubQuestionRowHeader> Question_SubQuestionRowHeader { get; set; }
        public virtual DbSet<SubQuestionRowHeader> SubQuestionRowHeaders { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<HardwareCompatibility> HardwareCompatibilities { get; set; }
        public virtual DbSet<AuditLog> AuditLog { get; set; }
        public virtual DbSet<StudyPrimaryReason> StudyPrimaryReasons { get; set; }
        public virtual DbSet<PrimaryReason> PrimaryReasons { get; set; }
        public virtual DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public virtual DbSet<PrimaryReasonsPhasesConfiguration> PrimaryReasonsPhasesConfigurations { get; set; }
        public virtual DbSet<ConsumableCompatibility> ConsumableCompatibilities { get; set; }
        public virtual DbSet<ChannelMapping> ChannelMappings { get; set; }
        public virtual DbSet<ChannelModel> ChannelModels { get; set; }
        public virtual DbSet<Eula> Eulas { get; set; }
        public virtual DbSet<ButtonModel> ButtonModels { get; set; }
        public virtual DbSet<ControlModel> ControlModels { get; set; }
        public virtual DbSet<UDS_TestData> UDS_TestData { get; set; }
        public virtual DbSet<FrameDetail> FrameDetails { get; set; }
        public virtual DbSet<Consumable> Consumables { get; set; }
        public virtual DbSet<PrimaryReasonsQuestionnairesConfiguration> PrimaryReasonsQuestionnairesConfigurations { get; set; }
        public virtual DbSet<QualityControlStep> QualityControlSteps { get; set; }
        public virtual DbSet<QualityControlStepsWithPhase> QualityControlStepsWithPhases { get; set; }
        public virtual DbSet<EventsHistory> EventsHistories { get; set; }
        public virtual DbSet<PhaseTextMarker> PhaseTextMarkers { get; set; }
        public virtual DbSet<PumpSpeedChange> PumpSpeedChanges { get; set; }
        public virtual DbSet<PumpSpeedLevel> PumpSpeedLevels { get; set; }
        public virtual DbSet<OffsetEvent> OffsetEvents { get; set; }
        public virtual DbSet<LoginFailureInfo> LoginFailureInfoes { get; set; }
        public virtual DbSet<ImageFrameResult> ImageFrameResults { get; set; }
        public virtual DbSet<ReferenceData> ReferenceDatas { get; set; }
        public virtual DbSet<ResultNormalValue> ResultNormalValues { get; set; }
        public virtual DbSet<QCScore> QCScores { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<SpecificGravity> SpecificGravities { get; set; }
    
        public virtual ObjectResult<GetPatientQuestionnaireScore_Result> GetPatientQuestionnaireScore(Nullable<long> patientQnrId)
        {
            var patientQnrIdParameter = patientQnrId.HasValue ?
                new ObjectParameter("patientQnrId", patientQnrId) :
                new ObjectParameter("patientQnrId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPatientQuestionnaireScore_Result>("GetPatientQuestionnaireScore", patientQnrIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateDoctor(string fname, string lname, string title)
        {
            var fnameParameter = fname != null ?
                new ObjectParameter("fname", fname) :
                new ObjectParameter("fname", typeof(string));
    
            var lnameParameter = lname != null ?
                new ObjectParameter("lname", lname) :
                new ObjectParameter("lname", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateDoctor", fnameParameter, lnameParameter, titleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateInvestigator(string fname, string lname, string title)
        {
            var fnameParameter = fname != null ?
                new ObjectParameter("fname", fname) :
                new ObjectParameter("fname", typeof(string));
    
            var lnameParameter = lname != null ?
                new ObjectParameter("lname", lname) :
                new ObjectParameter("lname", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateInvestigator", fnameParameter, lnameParameter, titleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateReferral(string fname, string lname, string title)
        {
            var fnameParameter = fname != null ?
                new ObjectParameter("fname", fname) :
                new ObjectParameter("fname", typeof(string));
    
            var lnameParameter = lname != null ?
                new ObjectParameter("lname", lname) :
                new ObjectParameter("lname", typeof(string));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateReferral", fnameParameter, lnameParameter, titleParameter);
        }
    
        public virtual ObjectResult<ReadDoctors_Result> ReadDoctors(string fullName, string pwd)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("fullName", fullName) :
                new ObjectParameter("fullName", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadDoctors_Result>("ReadDoctors", fullNameParameter, pwdParameter);
        }
    
        public virtual ObjectResult<ReadInvestigators_Result> ReadInvestigators(string fullName, string pwd)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("fullName", fullName) :
                new ObjectParameter("fullName", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadInvestigators_Result>("ReadInvestigators", fullNameParameter, pwdParameter);
        }
    
        public virtual ObjectResult<ReadReferrals_Result> ReadReferrals(string fullName, string pwd)
        {
            var fullNameParameter = fullName != null ?
                new ObjectParameter("fullName", fullName) :
                new ObjectParameter("fullName", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadReferrals_Result>("ReadReferrals", fullNameParameter, pwdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateDoctor(Nullable<int> doctorId, string title, string newFName, string newLName, Nullable<bool> visible)
        {
            var doctorIdParameter = doctorId.HasValue ?
                new ObjectParameter("doctorId", doctorId) :
                new ObjectParameter("doctorId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var newFNameParameter = newFName != null ?
                new ObjectParameter("newFName", newFName) :
                new ObjectParameter("newFName", typeof(string));
    
            var newLNameParameter = newLName != null ?
                new ObjectParameter("newLName", newLName) :
                new ObjectParameter("newLName", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateDoctor", doctorIdParameter, titleParameter, newFNameParameter, newLNameParameter, visibleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateInvestigator(Nullable<int> investigatorId, string title, string newFName, string newLName, Nullable<bool> visible)
        {
            var investigatorIdParameter = investigatorId.HasValue ?
                new ObjectParameter("investigatorId", investigatorId) :
                new ObjectParameter("investigatorId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var newFNameParameter = newFName != null ?
                new ObjectParameter("newFName", newFName) :
                new ObjectParameter("newFName", typeof(string));
    
            var newLNameParameter = newLName != null ?
                new ObjectParameter("newLName", newLName) :
                new ObjectParameter("newLName", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateInvestigator", investigatorIdParameter, titleParameter, newFNameParameter, newLNameParameter, visibleParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateReferral(Nullable<int> referralId, string title, string newFName, string newLName, Nullable<bool> visible)
        {
            var referralIdParameter = referralId.HasValue ?
                new ObjectParameter("referralId", referralId) :
                new ObjectParameter("referralId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var newFNameParameter = newFName != null ?
                new ObjectParameter("newFName", newFName) :
                new ObjectParameter("newFName", typeof(string));
    
            var newLNameParameter = newLName != null ?
                new ObjectParameter("newLName", newLName) :
                new ObjectParameter("newLName", typeof(string));
    
            var visibleParameter = visible.HasValue ?
                new ObjectParameter("visible", visible) :
                new ObjectParameter("visible", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateReferral", referralIdParameter, titleParameter, newFNameParameter, newLNameParameter, visibleParameter);
        }
    
        public virtual ObjectResult<ReadPatients_Result> ReadPatients(Nullable<int> hospitalId, Nullable<int> dbId, string pwd)
        {
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("hospitalId", hospitalId) :
                new ObjectParameter("hospitalId", typeof(int));
    
            var dbIdParameter = dbId.HasValue ?
                new ObjectParameter("dbId", dbId) :
                new ObjectParameter("dbId", typeof(int));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadPatients_Result>("ReadPatients", hospitalIdParameter, dbIdParameter, pwdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdatePatient(Nullable<int> dbId, Nullable<int> visibilityStatus, string patientId, Nullable<int> hospitalId, string firstName, string middleName, string lastName, Nullable<int> genderId, Nullable<System.DateTime> dateOfBirth, string maritalStatusId, string ethnicityId, byte[] icn, Nullable<int> height, Nullable<int> weight, string notes, string allergy, string personalNumber, string securityCode, string street, string suiteNumber, string city, string state, string country, string postalCode, string poBoxNumber, string phoneHome, string phoneMobile, Nullable<int> groupId, string insuranceCompany, string insurancePolicyNo, Nullable<int> doctorId, Nullable<int> investigatorId, Nullable<int> referringDoctorId, string history)
        {
            var dbIdParameter = dbId.HasValue ?
                new ObjectParameter("dbId", dbId) :
                new ObjectParameter("dbId", typeof(int));
    
            var visibilityStatusParameter = visibilityStatus.HasValue ?
                new ObjectParameter("visibilityStatus", visibilityStatus) :
                new ObjectParameter("visibilityStatus", typeof(int));
    
            var patientIdParameter = patientId != null ?
                new ObjectParameter("patientId", patientId) :
                new ObjectParameter("patientId", typeof(string));
    
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("hospitalId", hospitalId) :
                new ObjectParameter("hospitalId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("middleName", middleName) :
                new ObjectParameter("middleName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var genderIdParameter = genderId.HasValue ?
                new ObjectParameter("genderId", genderId) :
                new ObjectParameter("genderId", typeof(int));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("dateOfBirth", dateOfBirth) :
                new ObjectParameter("dateOfBirth", typeof(System.DateTime));
    
            var maritalStatusIdParameter = maritalStatusId != null ?
                new ObjectParameter("maritalStatusId", maritalStatusId) :
                new ObjectParameter("maritalStatusId", typeof(string));
    
            var ethnicityIdParameter = ethnicityId != null ?
                new ObjectParameter("ethnicityId", ethnicityId) :
                new ObjectParameter("ethnicityId", typeof(string));
    
            var icnParameter = icn != null ?
                new ObjectParameter("icn", icn) :
                new ObjectParameter("icn", typeof(byte[]));
    
            var heightParameter = height.HasValue ?
                new ObjectParameter("height", height) :
                new ObjectParameter("height", typeof(int));
    
            var weightParameter = weight.HasValue ?
                new ObjectParameter("weight", weight) :
                new ObjectParameter("weight", typeof(int));
    
            var notesParameter = notes != null ?
                new ObjectParameter("notes", notes) :
                new ObjectParameter("notes", typeof(string));
    
            var allergyParameter = allergy != null ?
                new ObjectParameter("allergy", allergy) :
                new ObjectParameter("allergy", typeof(string));
    
            var personalNumberParameter = personalNumber != null ?
                new ObjectParameter("personalNumber", personalNumber) :
                new ObjectParameter("personalNumber", typeof(string));
    
            var securityCodeParameter = securityCode != null ?
                new ObjectParameter("securityCode", securityCode) :
                new ObjectParameter("securityCode", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("street", street) :
                new ObjectParameter("street", typeof(string));
    
            var suiteNumberParameter = suiteNumber != null ?
                new ObjectParameter("suiteNumber", suiteNumber) :
                new ObjectParameter("suiteNumber", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("postalCode", postalCode) :
                new ObjectParameter("postalCode", typeof(string));
    
            var poBoxNumberParameter = poBoxNumber != null ?
                new ObjectParameter("poBoxNumber", poBoxNumber) :
                new ObjectParameter("poBoxNumber", typeof(string));
    
            var phoneHomeParameter = phoneHome != null ?
                new ObjectParameter("phoneHome", phoneHome) :
                new ObjectParameter("phoneHome", typeof(string));
    
            var phoneMobileParameter = phoneMobile != null ?
                new ObjectParameter("phoneMobile", phoneMobile) :
                new ObjectParameter("phoneMobile", typeof(string));
    
            var groupIdParameter = groupId.HasValue ?
                new ObjectParameter("groupId", groupId) :
                new ObjectParameter("groupId", typeof(int));
    
            var insuranceCompanyParameter = insuranceCompany != null ?
                new ObjectParameter("insuranceCompany", insuranceCompany) :
                new ObjectParameter("insuranceCompany", typeof(string));
    
            var insurancePolicyNoParameter = insurancePolicyNo != null ?
                new ObjectParameter("insurancePolicyNo", insurancePolicyNo) :
                new ObjectParameter("insurancePolicyNo", typeof(string));
    
            var doctorIdParameter = doctorId.HasValue ?
                new ObjectParameter("doctorId", doctorId) :
                new ObjectParameter("doctorId", typeof(int));
    
            var investigatorIdParameter = investigatorId.HasValue ?
                new ObjectParameter("investigatorId", investigatorId) :
                new ObjectParameter("investigatorId", typeof(int));
    
            var referringDoctorIdParameter = referringDoctorId.HasValue ?
                new ObjectParameter("referringDoctorId", referringDoctorId) :
                new ObjectParameter("referringDoctorId", typeof(int));
    
            var historyParameter = history != null ?
                new ObjectParameter("history", history) :
                new ObjectParameter("history", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdatePatient", dbIdParameter, visibilityStatusParameter, patientIdParameter, hospitalIdParameter, firstNameParameter, middleNameParameter, lastNameParameter, genderIdParameter, dateOfBirthParameter, maritalStatusIdParameter, ethnicityIdParameter, icnParameter, heightParameter, weightParameter, notesParameter, allergyParameter, personalNumberParameter, securityCodeParameter, streetParameter, suiteNumberParameter, cityParameter, stateParameter, countryParameter, postalCodeParameter, poBoxNumberParameter, phoneHomeParameter, phoneMobileParameter, groupIdParameter, insuranceCompanyParameter, insurancePolicyNoParameter, doctorIdParameter, investigatorIdParameter, referringDoctorIdParameter, historyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreatePatient(string patientId, Nullable<System.Guid> uuid, Nullable<int> visibilityStatus, Nullable<int> hospitalId, string firstName, string middleName, string lastName, Nullable<int> genderId, Nullable<System.DateTime> dateOfBirth, string maritalStatusId, string ethnicityId, byte[] icn, Nullable<int> height, Nullable<int> weight, string notes, string allergy, string personalNumber, string securityCode, string street, string suiteNumber, string city, string state, string country, string postalCode, string poBoxNumber, string phoneHome, string phoneMobile, Nullable<int> groupId, string insuranceCompany, string insurancePolicyNo, Nullable<int> doctorId, Nullable<int> investigatorId, Nullable<int> referringDoctorId, string history)
        {
            var patientIdParameter = patientId != null ?
                new ObjectParameter("patientId", patientId) :
                new ObjectParameter("patientId", typeof(string));
    
            var uuidParameter = uuid.HasValue ?
                new ObjectParameter("uuid", uuid) :
                new ObjectParameter("uuid", typeof(System.Guid));
    
            var visibilityStatusParameter = visibilityStatus.HasValue ?
                new ObjectParameter("visibilityStatus", visibilityStatus) :
                new ObjectParameter("visibilityStatus", typeof(int));
    
            var hospitalIdParameter = hospitalId.HasValue ?
                new ObjectParameter("hospitalId", hospitalId) :
                new ObjectParameter("hospitalId", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("middleName", middleName) :
                new ObjectParameter("middleName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var genderIdParameter = genderId.HasValue ?
                new ObjectParameter("genderId", genderId) :
                new ObjectParameter("genderId", typeof(int));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("dateOfBirth", dateOfBirth) :
                new ObjectParameter("dateOfBirth", typeof(System.DateTime));
    
            var maritalStatusIdParameter = maritalStatusId != null ?
                new ObjectParameter("maritalStatusId", maritalStatusId) :
                new ObjectParameter("maritalStatusId", typeof(string));
    
            var ethnicityIdParameter = ethnicityId != null ?
                new ObjectParameter("ethnicityId", ethnicityId) :
                new ObjectParameter("ethnicityId", typeof(string));
    
            var icnParameter = icn != null ?
                new ObjectParameter("icn", icn) :
                new ObjectParameter("icn", typeof(byte[]));
    
            var heightParameter = height.HasValue ?
                new ObjectParameter("height", height) :
                new ObjectParameter("height", typeof(int));
    
            var weightParameter = weight.HasValue ?
                new ObjectParameter("weight", weight) :
                new ObjectParameter("weight", typeof(int));
    
            var notesParameter = notes != null ?
                new ObjectParameter("notes", notes) :
                new ObjectParameter("notes", typeof(string));
    
            var allergyParameter = allergy != null ?
                new ObjectParameter("allergy", allergy) :
                new ObjectParameter("allergy", typeof(string));
    
            var personalNumberParameter = personalNumber != null ?
                new ObjectParameter("personalNumber", personalNumber) :
                new ObjectParameter("personalNumber", typeof(string));
    
            var securityCodeParameter = securityCode != null ?
                new ObjectParameter("securityCode", securityCode) :
                new ObjectParameter("securityCode", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("street", street) :
                new ObjectParameter("street", typeof(string));
    
            var suiteNumberParameter = suiteNumber != null ?
                new ObjectParameter("suiteNumber", suiteNumber) :
                new ObjectParameter("suiteNumber", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("state", state) :
                new ObjectParameter("state", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("country", country) :
                new ObjectParameter("country", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("postalCode", postalCode) :
                new ObjectParameter("postalCode", typeof(string));
    
            var poBoxNumberParameter = poBoxNumber != null ?
                new ObjectParameter("poBoxNumber", poBoxNumber) :
                new ObjectParameter("poBoxNumber", typeof(string));
    
            var phoneHomeParameter = phoneHome != null ?
                new ObjectParameter("phoneHome", phoneHome) :
                new ObjectParameter("phoneHome", typeof(string));
    
            var phoneMobileParameter = phoneMobile != null ?
                new ObjectParameter("phoneMobile", phoneMobile) :
                new ObjectParameter("phoneMobile", typeof(string));
    
            var groupIdParameter = groupId.HasValue ?
                new ObjectParameter("groupId", groupId) :
                new ObjectParameter("groupId", typeof(int));
    
            var insuranceCompanyParameter = insuranceCompany != null ?
                new ObjectParameter("insuranceCompany", insuranceCompany) :
                new ObjectParameter("insuranceCompany", typeof(string));
    
            var insurancePolicyNoParameter = insurancePolicyNo != null ?
                new ObjectParameter("insurancePolicyNo", insurancePolicyNo) :
                new ObjectParameter("insurancePolicyNo", typeof(string));
    
            var doctorIdParameter = doctorId.HasValue ?
                new ObjectParameter("doctorId", doctorId) :
                new ObjectParameter("doctorId", typeof(int));
    
            var investigatorIdParameter = investigatorId.HasValue ?
                new ObjectParameter("investigatorId", investigatorId) :
                new ObjectParameter("investigatorId", typeof(int));
    
            var referringDoctorIdParameter = referringDoctorId.HasValue ?
                new ObjectParameter("referringDoctorId", referringDoctorId) :
                new ObjectParameter("referringDoctorId", typeof(int));
    
            var historyParameter = history != null ?
                new ObjectParameter("history", history) :
                new ObjectParameter("history", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreatePatient", patientIdParameter, uuidParameter, visibilityStatusParameter, hospitalIdParameter, firstNameParameter, middleNameParameter, lastNameParameter, genderIdParameter, dateOfBirthParameter, maritalStatusIdParameter, ethnicityIdParameter, icnParameter, heightParameter, weightParameter, notesParameter, allergyParameter, personalNumberParameter, securityCodeParameter, streetParameter, suiteNumberParameter, cityParameter, stateParameter, countryParameter, postalCodeParameter, poBoxNumberParameter, phoneHomeParameter, phoneMobileParameter, groupIdParameter, insuranceCompanyParameter, insurancePolicyNoParameter, doctorIdParameter, investigatorIdParameter, referringDoctorIdParameter, historyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CreateAuditLog(string message)
        {
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CreateAuditLog", messageParameter);
        }
    
        public virtual ObjectResult<ReadAuditLog_Result> ReadAuditLog(Nullable<int> iD, string pwd)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReadAuditLog_Result>("ReadAuditLog", iDParameter, pwdParameter);
        }
    }
}
