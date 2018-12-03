using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeOfClones.Models
{
    public class TransactionViewModel
    {
        public TransactionViewModel(
            string updateAction,
            int itemId,
            string itemName,
            SelectList correspondigItem,
            decimal value,
            decimal pricePerOne,
            bool canDoOperation)
        {
            UpdateAction = updateAction;
            ItemId = itemId;
            ItemName = itemName;
            CorrespondingItem = correspondigItem;
            Value = value;
            PricePerOne = pricePerOne;
            TotalPrice = Value * PricePerOne;
            CanDoOperation = canDoOperation;
        }

        public string UpdateAction { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public SelectList CorrespondingItem { get; set; }

        public decimal Value { get; set; }
        public decimal PricePerOne { get; set; }
        public decimal TotalPrice { get; set; }

        public bool CanDoOperation { get; set; }
    }
}
