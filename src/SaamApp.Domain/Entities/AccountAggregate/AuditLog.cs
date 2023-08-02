using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class AuditLog : BaseEntityEv<Guid>, IAggregateRoot
    {
        private AuditLog() { } // EF required

        //[SetsRequiredMembers]
        public AuditLog(Guid auditLogId, DateTime eventDateUTC, Guid applicationUserId, string? userName,
            string? userRoles, Guid tenantId, string eventType, string? tableName, string recordId,
            string? operationType, string? oldValues, string? newValues, string? changesMade, string? changeReason,
            string? operationResult, string? affectedFields, string? ipAddress, string? userAgent,
            string? additionalInfo)
        {
            AuditLogId = Guard.Against.NullOrEmpty(auditLogId, nameof(auditLogId));
            EventDateUTC = Guard.Against.OutOfSQLDateRange(eventDateUTC, nameof(eventDateUTC));
            ApplicationUserId = Guard.Against.NullOrEmpty(applicationUserId, nameof(applicationUserId));
            UserName = userName;
            UserRoles = userRoles;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
            EventType = Guard.Against.NullOrWhiteSpace(eventType, nameof(eventType));
            TableName = tableName;
            RecordId = Guard.Against.NullOrWhiteSpace(recordId, nameof(recordId));
            OperationType = operationType;
            OldValues = oldValues;
            NewValues = newValues;
            ChangesMade = changesMade;
            ChangeReason = changeReason;
            OperationResult = operationResult;
            AffectedFields = affectedFields;
            IpAddress = ipAddress;
            UserAgent = userAgent;
            AdditionalInfo = additionalInfo;
        }

        [Key] public Guid AuditLogId { get; private set; }

        public DateTime EventDateUTC { get; private set; }

        public Guid ApplicationUserId { get; private set; }

        public string? UserName { get; private set; }

        public string? UserRoles { get; private set; }

        public Guid TenantId { get; private set; }

        public string EventType { get; private set; }

        public string? TableName { get; private set; }

        public string RecordId { get; private set; }

        public string? OperationType { get; private set; }

        public string? OldValues { get; private set; }

        public string? NewValues { get; private set; }

        public string? ChangesMade { get; private set; }

        public string? ChangeReason { get; private set; }

        public string? OperationResult { get; private set; }

        public string? AffectedFields { get; private set; }

        public string? IpAddress { get; private set; }

        public string? UserAgent { get; private set; }

        public string? AdditionalInfo { get; private set; }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        public void SetUserRoles(string userRoles)
        {
            UserRoles = userRoles;
        }

        public void SetEventType(string eventType)
        {
            EventType = Guard.Against.NullOrEmpty(eventType, nameof(eventType));
        }

        public void SetTableName(string tableName)
        {
            TableName = tableName;
        }

        public void SetRecordId(string recordId)
        {
            RecordId = Guard.Against.NullOrEmpty(recordId, nameof(recordId));
        }

        public void SetOperationType(string operationType)
        {
            OperationType = operationType;
        }

        public void SetOldValues(string oldValues)
        {
            OldValues = oldValues;
        }

        public void SetNewValues(string newValues)
        {
            NewValues = newValues;
        }

        public void SetChangesMade(string changesMade)
        {
            ChangesMade = changesMade;
        }

        public void SetChangeReason(string changeReason)
        {
            ChangeReason = changeReason;
        }

        public void SetOperationResult(string operationResult)
        {
            OperationResult = operationResult;
        }

        public void SetAffectedFields(string affectedFields)
        {
            AffectedFields = affectedFields;
        }

        public void SetIpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public void SetUserAgent(string userAgent)
        {
            UserAgent = userAgent;
        }

        public void SetAdditionalInfo(string additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}