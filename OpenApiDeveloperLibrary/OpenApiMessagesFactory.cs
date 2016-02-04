using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenApiLib.Proto;
using ProtoBuf;
using System.IO;


namespace OpenApiDeveloperLibrary
{
    public class OpenApiMessagesFactory
    {
        uint lastMessagePayloadType = 0;
        byte[] lastMessagePayload = null;

        #region Building Proto messages from Byte array methods
        public ProtoMessage GetMessage(byte[] msg)
        {
            var _msg = Utils.Deserialize<ProtoMessage>(msg);
            lastMessagePayloadType = _msg.payloadType;
            lastMessagePayload = _msg.payload;
            return _msg;
        }
        public uint GetPayloadType(byte[] msg = null)
        {
            if (msg != null)
                GetMessage(msg);
            return lastMessagePayloadType;
        }
        public byte[] GetPayload(byte[] msg = null)
        {
            if (msg != null)
                GetMessage(msg);
            return lastMessagePayload;
        }

        public ProtoPingReq GetPingRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoPingReq>(GetPayload(msg));
        }
        public ProtoPingRes GetPingResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoPingRes>(GetPayload(msg));
        }
        public ProtoHeartbeatEvent GetHeartbeatEvent(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoHeartbeatEvent>(GetPayload(msg));
        }
        public ProtoErrorRes GetErrorResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoErrorRes>(GetPayload(msg));
        }
        public ProtoOAAuthReq GetAuthorizationRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAAuthReq>(GetPayload(msg));
        }
        public ProtoOAAuthRes GetAuthorizationResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAAuthRes>(GetPayload(msg));
        }
        public ProtoOASubscribeForTradingEventsReq GetSubscribeForTradingEventsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOASubscribeForTradingEventsReq>(GetPayload(msg));
        }
        public ProtoOASubscribeForTradingEventsRes GetSubscribeForTradingEventsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOASubscribeForTradingEventsRes>(GetPayload(msg));
        }
        public ProtoOAUnsubscribeFromTradingEventsReq GetUnsubscribeForTradingEventsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAUnsubscribeFromTradingEventsReq>(GetPayload(msg));
        }
        public ProtoOAUnsubscribeFromTradingEventsRes GetUnsubscribeForTradingEventsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAUnsubscribeFromTradingEventsRes>(GetPayload(msg));
        }
        public ProtoOAGetSubscribedAccountsReq GetAllSubscriptionsForTradingEventsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetSubscribedAccountsReq>(GetPayload(msg));
        }
        public ProtoOAGetSubscribedAccountsRes GetAllSubscriptionsForTradingEventsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetSubscribedAccountsRes>(GetPayload(msg));
        }
        public ProtoOAExecutionEvent GetExecutionEvent(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAExecutionEvent>(GetPayload(msg));
        }
        public ProtoOACreateOrderReq GetCreateOrderRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOACreateOrderReq>(GetPayload(msg));
        }
        public ProtoOACancelOrderReq GetCancelOrderRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOACancelOrderReq>(GetPayload(msg));
        }
        public ProtoOAClosePositionReq GetClosePositionRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAClosePositionReq>(GetPayload(msg));
        }
        public ProtoOAAmendPositionStopLossTakeProfitReq GetAmendPositionStopLossTakeProfitRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAAmendPositionStopLossTakeProfitReq>(GetPayload(msg));
        }
        public ProtoOAAmendOrderReq GetAmendOrderRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAAmendOrderReq>(GetPayload(msg));
        }
        public ProtoOASubscribeForSpotsReq GetSubscribeForSpotsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOASubscribeForSpotsReq>(GetPayload(msg));
        }
        public ProtoOASubscribeForSpotsRes GetSubscribeForSpotsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOASubscribeForSpotsRes>(GetPayload(msg));
        }
        public ProtoOAUnsubscribeFromSpotsReq GetUnsubscribeFromSpotsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAUnsubscribeFromSpotsReq>(GetPayload(msg));
        }
        public ProtoOAUnsubscribeFromSpotsRes GetUnsubscribeFromSpotsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAUnsubscribeFromSpotsRes>(GetPayload(msg));
        }
        public ProtoOAGetSpotSubscriptionReq GetGetSpotSubscriptionRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetSpotSubscriptionReq>(GetPayload(msg));
        }
        public ProtoOAGetSpotSubscriptionRes GetGetSpotSubscriptionResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetSpotSubscriptionRes>(GetPayload(msg));
        }
        public ProtoOAGetAllSpotSubscriptionsReq GetGetAllSpotSubscriptionsRequest(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetAllSpotSubscriptionsReq>(GetPayload(msg));
        }
        public ProtoOAGetAllSpotSubscriptionsRes GetGetAllSpotSubscriptionsResponse(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOAGetAllSpotSubscriptionsRes>(GetPayload(msg));
        }
        public ProtoOASpotEvent GetSpotEvent(byte[] msg = null)
        {
            return Utils.Deserialize<ProtoOASpotEvent>(GetPayload(msg));
        }
        #endregion

        #region Creating new Proto messages with parameters specified
        public ProtoMessage CreateMessage(uint payloadType, byte[] payload = null, string clientMsgId = null)
        {
            var protoMsg = new ProtoMessage();
            protoMsg.payloadType = payloadType;
            if (payload != null)
                protoMsg.payload = payload;
            if (clientMsgId != null)
                protoMsg.clientMsgId = clientMsgId;

            return protoMsg;
        }
        public ProtoMessage CreatePingRequest(ulong timestamp, string clientMsgId = null)
        {
            ProtoPingReq _msg = new ProtoPingReq();
            _msg.timestamp = timestamp;
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, Utils.Serialize<ProtoPingReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreatePingResponse(ulong timestamp, string clientMsgId = null)
        {
            ProtoPingRes _msg = new ProtoPingRes();
            _msg.timestamp = timestamp;
            return CreateMessage((uint)ProtoPayloadType.PING_REQ, Utils.Serialize<ProtoPingRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateHeartbeatEvent(string clientMsgId = null)
        {
            ProtoHeartbeatEvent _msg = new ProtoHeartbeatEvent();
            return CreateMessage((uint)ProtoPayloadType.HEARTBEAT_EVENT, Utils.Serialize<ProtoHeartbeatEvent>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAuthorizationRequest(string clientId, string clientSecret, string clientMsgId = null)
        {
            var _msg = new ProtoOAAuthReq();
            _msg.clientId = clientId;
            _msg.clientSecret = clientSecret;
            return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAuthReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAuthorizationResponse(string clientMsgId = null)
        {
            var _msg = new ProtoOAAuthRes();
            return CreateMessage((uint)ProtoOAPayloadType.OA_AUTH_RES, Utils.Serialize<ProtoOAAuthRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForTradingEventsRequest(long accountId, string accessToken, string clientMsgId = null)
        {
            var _msg = new ProtoOASubscribeForTradingEventsReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOASubscribeForTradingEventsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForTradingEventsResponse(string clientMsgId = null)
        {
			var _msg = new ProtoOASubscribeForTradingEventsRes ();
            return CreateMessage((uint)ProtoOAPayloadType.OA_SUBSCRIBE_FOR_TRADING_EVENTS_RES, Utils.Serialize<ProtoOASubscribeForTradingEventsRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeForTradingEventsRequest(long accountId, string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromTradingEventsReq();
            _msg.accountId = accountId;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromTradingEventsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeForTradingEventsResponse(string clientMsgId = null)
        {
			var _msg = new ProtoOAUnsubscribeFromTradingEventsRes();
            return CreateMessage((uint)ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_TRADING_EVENTS_RES, Utils.Serialize<ProtoOAUnsubscribeFromTradingEventsRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAllSubscriptionsForTradingEventsRequest(string clientMsgId = null)
        {
			var _msg = new ProtoOAGetSubscribedAccountsReq ();
            return CreateMessage((uint)ProtoOAPayloadType.OA_GET_SUBSCRIBED_ACCOUNTS_REQ, Utils.Serialize<ProtoOAGetSubscribedAccountsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAllSubscriptionsForTradingEventsResponse(List<long> accountIdsList, string clientMsgId = null)
        {
            var _msg = new ProtoOAGetSubscribedAccountsRes();
			foreach (var accountId in accountIdsList)
				_msg.accountId.Add(accountId);
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAGetSubscribedAccountsRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateExecutionEvent(ProtoOAExecutionType executionType, ProtoOAOrder order, ProtoOAPosition position = null, string reasonCode = null, string clientMsgId = null)
        {
            var _msg = new ProtoOAExecutionEvent();
            _msg.executionType = executionType;
            _msg.order = order;
            if (position != null)
                _msg.position = position;
            if (reasonCode != null)
                _msg.reasonCode = reasonCode;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAExecutionEvent>(_msg), clientMsgId);
        }

        public ProtoMessage CreateMarketOrderRequest(long accountId, string accessToken, string symbolName, ProtoTradeSide tradeSide, long volume, string clientMsgId = null)
        {
            var _msg = new ProtoOACreateOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.symbolName = symbolName;
            _msg.orderType = ProtoOAOrderType.OA_MARKET;
            _msg.tradeSide = tradeSide;
            _msg.volume = volume;

            //_msg.27 = 27;
            //_msg.1 = 1;

            _msg.comment = "TradingApiTest.CreateMarketOrderRequest";
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOACreateOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateMarketRangeOrderRequest(long accountId, string accessToken, string symbolName, ProtoTradeSide tradeSide, long volume, double baseSlippagePrice, long slippageInPips, string clientMsgId = null)
        {
            var _msg = new ProtoOACreateOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.symbolName = symbolName;
            _msg.orderType = ProtoOAOrderType.OA_MARKET_RANGE;
            _msg.tradeSide = tradeSide;
            _msg.volume = volume;
            _msg.baseSlippagePrice = baseSlippagePrice;
            _msg.slippageInPips = slippageInPips;
            _msg.comment = "TradingApiTest.CreateMarketRangeOrderRequest";
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOACreateOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateLimitOrderRequest(long accountId, string accessToken, string symbolName, ProtoTradeSide tradeSide, long volume, double limitPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOACreateOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.symbolName = symbolName;
            _msg.orderType = ProtoOAOrderType.OA_LIMIT;
            _msg.tradeSide = tradeSide;
            _msg.volume = volume;
            _msg.limitPrice = limitPrice;
            _msg.comment = "TradingApiTest.CreateLimitOrderRequest";
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOACreateOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateStopOrderRequest(long accountId, string accessToken, string symbolName, ProtoTradeSide tradeSide, long volume, double stopPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOACreateOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.symbolName = symbolName;
            _msg.orderType = ProtoOAOrderType.OA_STOP;
            _msg.tradeSide = tradeSide;
            _msg.volume = volume;
            _msg.stopPrice = stopPrice;
            _msg.comment = "TradingApiTest.CreateStopOrderRequest";
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOACreateOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateCancelOrderRequest(long accountId, string accessToken, long orderId, string clientMsgId = null)
        {
            var _msg = new ProtoOACancelOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.orderId = orderId;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOACancelOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateClosePositionRequest(long accountId, string accessToken, long positionId, long volume, string clientMsgId = null)
        {
            var _msg = new ProtoOAClosePositionReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.positionId = positionId;
            _msg.volume = volume;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAClosePositionReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionStopLossRequest(long accountId, string accessToken, long positionId, double stopLossPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOAAmendPositionStopLossTakeProfitReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.positionId = positionId;
            _msg.stopLossPrice = stopLossPrice;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAmendPositionStopLossTakeProfitReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionTakeProfitRequest(long accountId, string accessToken, long positionId, double takeProfitPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOAAmendPositionStopLossTakeProfitReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.positionId = positionId;
            _msg.takeProfitPrice = takeProfitPrice;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAmendPositionStopLossTakeProfitReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAmendPositionProtectionRequest(long accountId, string accessToken, long positionId, double stopLossPrice, double takeProfitPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOAAmendPositionStopLossTakeProfitReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.positionId = positionId;
            _msg.stopLossPrice = stopLossPrice;
            _msg.takeProfitPrice = takeProfitPrice;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAmendPositionStopLossTakeProfitReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAmendLimitOrderRequest(long accountId, string accessToken, long orderId, double limitPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOAAmendOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.orderId = orderId;
            _msg.limitPrice = limitPrice;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAmendOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateAmendStopOrderRequest(long accountId, string accessToken, long orderId, double stopPrice, string clientMsgId = null)
        {
            var _msg = new ProtoOAAmendOrderReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.orderId = orderId;
            _msg.stopPrice = stopPrice;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAAmendOrderReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForSpotsRequest(long accountId, string accessToken, string symbolName, string clientMsgId = null)
        {
            var _msg = new ProtoOASubscribeForSpotsReq();
            _msg.accountId = accountId;
            _msg.accessToken = accessToken;
            _msg.symblolName = symbolName;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOASubscribeForSpotsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateSubscribeForSpotsResponse(uint subscriptionId, string clientMsgId = null)
        {
            var _msg = new ProtoOASubscribeForSpotsRes();
            _msg.subscriptionId = subscriptionId;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOASubscribeForSpotsRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeFromAllSpotsRequest(string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromSpotsReq();
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromSpotsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeAccountFromSpotsRequest(uint subscriptionId, string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromSpotsReq();
            _msg.subscriptionId = subscriptionId;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromSpotsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeFromSymbolSpotsRequest(string symbolName, string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromSpotsReq();
            _msg.symblolName = symbolName;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromSpotsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeAccountFromSymbolSpotsRequest(uint subscriptionId, string symbolName, string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromSpotsReq();
            _msg.subscriptionId = subscriptionId;
            _msg.symblolName = symbolName;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromSpotsReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateUnsubscribeFromSpotsResponse(string clientMsgId = null)
        {
            var _msg = new ProtoOAUnsubscribeFromSpotsRes();
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAUnsubscribeFromSpotsRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateGetSpotSubscriptionRequest(uint subscriptionId, string clientMsgId = null)
        {
            var _msg = new ProtoOAGetSpotSubscriptionReq();
            _msg.subscriptionId = subscriptionId;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAGetSpotSubscriptionReq>(_msg), clientMsgId);
        }
        public ProtoMessage CreateGetSpotSubscriptionResponse(ProtoOASpotSubscription spotSubscription, string clientMsgId = null)
        {
            var _msg = new ProtoOAGetSpotSubscriptionRes();
            _msg.spotSubscription = spotSubscription;
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAGetSpotSubscriptionRes>(_msg), clientMsgId);
        }
        public ProtoMessage CreateGetAllSpotSubscriptionsRequest(string clientMsgId = null)
        {
            var _msg = new ProtoOAGetAllSpotSubscriptionsReq();
			return CreateMessage((uint)_msg.payloadType, Utils.Serialize<ProtoOAGetAllSpotSubscriptionsReq>(_msg), clientMsgId);
        }
        #endregion

        #region Creating new Proto messages Builders
        public ProtoOAGetAllSpotSubscriptionsRes CreateGetAllSpotSubscriptionsResponseBuilder(string clientMsgId = null)
        {
            return new ProtoOAGetAllSpotSubscriptionsRes();
        }
        public ProtoOASpotEvent CreateSpotEventBuilder(uint subscriptionId, string symbolName, string clientMsgId = null)
        {
            return new ProtoOASpotEvent ();
        }
        #endregion
    }
}
