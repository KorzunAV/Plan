using System;
using System.Collections.Generic;

namespace Entities
{
    /// <summary>
    /// Денежный перевод
    /// </summary>
    public class Transaction : EntityBase
    {
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public virtual Nullable<DateTime> RegistrationDate { get; set; }

        /// <summary>
        /// Дата транзакции
        /// </summary>
        public virtual Nullable<DateTime> TransactionDate { get; set; }

        /// <summary>
        /// Номер транзакции / Документа
        /// </summary>
        public virtual string TransactionNumber { get; set; }

        /// <summary>
        /// Код транзакции
        /// </summary>
        public virtual string TransactionCode { get; set; }

        /// <summary>
        /// Валюта перевода.
        /// </summary>
        public virtual CurrencyType CurrencyType { get; set; }

        /// <summary>
        /// Размер перевода.
        /// </summary>
        public virtual decimal Value { get; set; }

        /// <summary>
        /// Счет отправителя
        /// </summary>
        public virtual CashAccount SenderCashAccount { get; set; }

        /// <summary>
        /// Счет получателя
        /// </summary>
        public virtual CashAccount ReceiverCashAccount { get; set; }

        /// <summary>
        /// Тип перевода
        /// </summary>
        public virtual TransferType TransferType { get; set; }

        /// <summary>
        /// Подтип денежного перевода.
        /// </summary>
        public virtual TransferSubType TransferSubType { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public virtual string Comment { get; set; }

        /// <summary>
        /// Пользовательские теги.
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
    }
}