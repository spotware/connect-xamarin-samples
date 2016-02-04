using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenApiLib.Proto;
using ProtoBuf;


namespace OpenApiDeveloperLibrary
{
    public class OpenApiModelObjectsFactory
    {
        #region Building Proto Model objects from Byte array methods
        public ProtoOAOrder GetOrder(byte[] obj = null)
        {
            return Utils.Deserialize<ProtoOAOrder>(obj);
        }
        public ProtoOAPosition GetPosition(byte[] obj = null)
        {
            return Utils.Deserialize<ProtoOAPosition>(obj);
        }
        public ProtoOAClosePositionDetails GetClosePositionDetails(byte[] obj = null)
        {
            return Utils.Deserialize<ProtoOAClosePositionDetails>(obj);
        }
        public ProtoOASpotSubscription GetSpotSubscription(byte[] obj = null)
        {
            return Utils.Deserialize<ProtoOASpotSubscription>(obj);
        }
        #endregion

        #region Creating new Proto Model objects with parameters specified
        public ProtoOAOrder CreateOrder(long orderId, long accountId, ProtoOAOrderType orderType,
            ProtoTradeSide tradeSide, string symbolName, long requestedVolume, long executedVolume, bool closingOrder,
            string channel = null, string comment=null)
        {
            var _obj = new ProtoOAOrder();
            _obj.orderId = orderId;
            _obj.accountId = accountId;
            _obj.orderType = orderType;
            _obj.tradeSide = tradeSide;
            _obj.symbolName = symbolName;
            _obj.requestedVolume = requestedVolume;
            _obj.executedVolume = executedVolume;
            _obj.closingOrder = closingOrder;
            if (channel != null)
                _obj.channel = channel;
            if (comment != null)
                _obj.comment = comment;
            return _obj;
        }
        public ProtoOAPosition CreatePosition(long positionId, ProtoOAPositionStatus positionStatus, long accountId,
            ProtoTradeSide tradeSide, string symbolName, long volume, double entryPrice, long swap,
            long commission, long openTimestamp, string channel = null, string comment = null)
        {
            var _obj = new ProtoOAPosition();
            _obj.positionId = positionId;
            _obj.positionStatus = positionStatus;
            _obj.accountId = accountId;
            _obj.tradeSide = tradeSide;
            _obj.symbolName = symbolName;
            _obj.volume = volume;
            _obj.entryPrice = entryPrice;
            _obj.swap = swap;
            _obj.commission = commission;
            _obj.openTimestamp = openTimestamp;
            if (channel != null)
                _obj.channel = channel;
            if (comment != null)
                _obj.comment = comment;
            return _obj;
        }
        public ProtoOAClosePositionDetails CreateClosePositionDetails(double entryPrice, long profit, long swap, long commission, 
			long balance, long closedVolume, bool closedByStopOut, string comment = null)
        {
            var _obj = new ProtoOAClosePositionDetails();
            _obj.entryPrice = entryPrice;
            _obj.profit = profit;
            _obj.swap = swap;
            _obj.commission = commission;
            _obj.balance = balance;
            _obj.closedVolume = closedVolume;
            _obj.closedByStopOut = closedByStopOut;
            if (comment != null)
                _obj.comment = comment;
            return _obj;
        }
        public ProtoOASpotSubscription CreateSpotSubscription(long accountId, uint subscriptionId)
        {
            var _obj = new ProtoOASpotSubscription();
            _obj.accountId = accountId;
            _obj.subscriptionId = subscriptionId;
            return _obj;
        }
        #endregion
    }
}
