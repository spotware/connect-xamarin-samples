using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenApiLib.Proto;
using ProtoBuf;

namespace OpenApiDeveloperLibrary
{
    public class OpenApiMessagesPresentation
    {
        static string ProtoMessageToString(ProtoMessage msg)
        {
            if (!msg.payloadSpecified)
                return "ERROR in ProtoMessage: Corrupted execution event, no payload found";
            var _str = "ProtoMessage{";
            switch ((ProtoPayloadType)msg.payloadType)
            {
                case ProtoPayloadType.PROTO_MESSAGE:
                    var _msg = Utils.Deserialize<ProtoMessage>(msg.payload);
                    _str += ProtoMessageToString(_msg);
                    break;
                case ProtoPayloadType.PING_REQ:
                    var _ping_req = Utils.Deserialize<ProtoPingReq>(msg.payload);
                    _str += "PingRequest{timestamp:" + _ping_req.timestamp.ToString() + "}";
                    break;
                case ProtoPayloadType.PING_RES:
                    var _ping_res = Utils.Deserialize<ProtoPingRes>(msg.payload);
                    _str += "PingResponse{timestamp:" + _ping_res.timestamp + "}";
                    break;
                case ProtoPayloadType.HEARTBEAT_EVENT:
                    var _hb = Utils.Deserialize<ProtoHeartbeatEvent>(msg.payload);
                    _str += "Heartbeat";
                    break;
                case ProtoPayloadType.ERROR_RES:
                    var _err = Utils.Deserialize<ProtoErrorRes>(msg.payload);
                    _str += "ErrorResponse{errorCode:" + _err.errorCode + (_err.descriptionSpecified ? ", description:" + _err.description : "") + "}";
                    break;
                default:
                    _str += OpenApiMessageToString(msg);
                    break;
            }
			_str += (msg.clientMsgIdSpecified ? ", clientMsgId:" + msg.clientMsgId : "") + (msg.payloadSpecified ? ", payloadString:" + msg.payload : "") + "}";

            return _str;
        }
        static string OpenApiMessageToString(ProtoMessage msg)
        {
            switch ((ProtoOAPayloadType)msg.payloadType)
            {
                case ProtoOAPayloadType.OA_AUTH_REQ:
                    var _auth_req = Utils.Deserialize<ProtoOAAuthReq>(msg.payload);
                    return "AuthRequest{clientId:" + _auth_req.clientId + ", clientSecret:" + _auth_req.clientSecret + "}";
                case ProtoOAPayloadType.OA_AUTH_RES:
                    return "AuthResponse";
                case ProtoOAPayloadType.OA_GET_SUBSCRIBED_ACCOUNTS_REQ:
                    return "GetSubscribedAccountsRequest";
                case ProtoOAPayloadType.OA_GET_SUBSCRIBED_ACCOUNTS_RES:
                    var _subscr_res = Utils.Deserialize<ProtoOAGetSubscribedAccountsRes>(msg.payload);
                    var _subscr_res_str = "GetSubscribedAccountsResponse{";
					var _subscr_count = _subscr_res.accountId.Count;
                    foreach (var accountId in _subscr_res.accountId)
                        _subscr_res_str += "accountId:" + accountId.ToString() + (--_subscr_count == 0 ? "" : ", ");
                    return _subscr_res_str + "}";
                case ProtoOAPayloadType.OA_SUBSCRIBE_FOR_TRADING_EVENTS_REQ:
                    var _subscr_req = Utils.Deserialize<ProtoOASubscribeForTradingEventsReq>(msg.payload);
                    return "SubscrbeTradingEventsRequest{accountId:" + _subscr_req.accountId.ToString() + ", accessToken:" + _subscr_req.accessToken + "}";
                case ProtoOAPayloadType.OA_SUBSCRIBE_FOR_TRADING_EVENTS_RES:
                    return "SubscrbeTradingEventsResponse";
                case ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_TRADING_EVENTS_REQ:
                    var _unsubscr_req = Utils.Deserialize<ProtoOAUnsubscribeFromTradingEventsReq>(msg.payload);
                    return "UnsubscrbeTradingEventsRequest{accountId:" + _unsubscr_req.accountId + "}";
                case ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_TRADING_EVENTS_RES:
                    return "UnsubscrbeTradingEventsResponse";
                case ProtoOAPayloadType.OA_EXECUTION_EVENT:
                    return OpenApiExecEventsToString(msg);
                case ProtoOAPayloadType.OA_CANCEL_ORDER_REQ:
                    return "CancelOrderRequest{}";
                case ProtoOAPayloadType.OA_CREATE_ORDER_REQ:
                    return "CreateOrderRequest{}";
                case ProtoOAPayloadType.OA_CLOSE_POSITION_REQ:
                    return "ClosePositionRequest{}";
                case ProtoOAPayloadType.OA_AMEND_ORDER_REQ:
                    return "AmendOrderRequest{}";
                case ProtoOAPayloadType.OA_AMEND_POSITION_SL_TP_REQ:
                    return "AmendPositionRequest{}";
                case ProtoOAPayloadType.OA_SUBSCRIBE_FOR_SPOTS_REQ:
                    return "SubscribeForSpotsRequest{}";
                case ProtoOAPayloadType.OA_SUBSCRIBE_FOR_SPOTS_RES:
                    return "SubscribeForSpotsResponse{}";
                case ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_SPOTS_REQ:
                    return "UnsubscribeFromSpotsRequest{}";
                case ProtoOAPayloadType.OA_UNSUBSCRIBE_FROM_SPOTS_RES:
                    return "UnsubscribeFromSpotsResponse{}";
                case ProtoOAPayloadType.OA_GET_SPOT_SUBSCRIPTION_REQ:
                    return "GetSpotSubscriptionRequest{}";
                case ProtoOAPayloadType.OA_GET_SPOT_SUBSCRIPTION_RES:
                    return "GetSpotSubscriptionResponse{}";
                case ProtoOAPayloadType.OA_GET_ALL_SPOT_SUBSCRIPTIONS_REQ:
                    return "GetAllSpotSubscriptionsRequest{}";
                case ProtoOAPayloadType.OA_GET_ALL_SPOT_SUBSCRIPTIONS_RES:
                    String _all_str = "GetAllSpotSubscriptionsResponse{";
                     ProtoOAGetAllSpotSubscriptionsRes _all_res = Utils.Deserialize<ProtoOAGetAllSpotSubscriptionsRes>(msg.payload);
                     _all_str += "subscriptions=[";
                     foreach (ProtoOASpotSubscription subscription in _all_res.spotSubscriptions) {
                        _all_str += "{AccountId=" + subscription.accountId + ", SubscriptionId=" + subscription.subscriptionId + ", SymbolNamesList=[";
                        foreach (String symbolName in subscription.symbolNames) {
                            _all_str += symbolName + ", ";
                        }
                        _all_str += "]}, ";
                        }
                    _all_str += "]}";
                    return _all_str;
                case ProtoOAPayloadType.OA_SPOT_EVENT:
                    var _spot_event = Utils.Deserialize<ProtoOASpotEvent>(msg.payload);
                    return "SpotEvent{subscriptionId:" + _spot_event.subscriptionId + ", symbolName:" + _spot_event.symbolName + 
					", bidPrice:" + (_spot_event.bidPriceSpecified ? _spot_event.bidPrice.ToString() : "       ") + 
					", askPrice:" + (_spot_event.askPriceSpecified ? _spot_event.askPrice.ToString() : "       ") + "}";
                default:
                    return "unknown";
            }
        }
        static string OpenApiExecutionTypeToString(ProtoOAExecutionType executionType)
        {
            switch (executionType)
            {
                case ProtoOAExecutionType.OA_ORDER_ACCEPTED:
                    return "OrderAccepted";
                case ProtoOAExecutionType.OA_ORDER_AMENDED:
                    return "OrderAmended";
                case ProtoOAExecutionType.OA_ORDER_CANCEL_REJECTED:
                    return "OrderCancelRejected";
                case ProtoOAExecutionType.OA_ORDER_CANCELLED:
                    return "OrderCancelled";
                case ProtoOAExecutionType.OA_ORDER_EXPIRED:
                    return "OrderExpired";
                case ProtoOAExecutionType.OA_ORDER_FILLED:
                    return "OrderFilled";
                case ProtoOAExecutionType.OA_ORDER_REJECTED:
                    return "OrderRejected";
                default:
                    return "unknown";
            }
        }
        static string OpenApiExecEventsToString(ProtoMessage msg)
        {
            if ((ProtoOAPayloadType)msg.payloadType != ProtoOAPayloadType.OA_EXECUTION_EVENT)
                return "ERROR in OpenApiExecutionEvents: Wrong message type";

            if (!msg.payloadSpecified)
                return "ERROR in OpenApiExecutionEvents: Corrupted execution event, no payload found";

            var _msg = Utils.Deserialize<ProtoOAExecutionEvent>(msg.payload);
            var _str = OpenApiExecutionTypeToString(_msg.executionType) + "{" +
                OpenApiOrderToString(_msg.order) +
                ", " + OpenApiPositionToString(_msg.position) +
                (_msg.reasonCodeSpecified ? ", reasonCode:" + _msg.reasonCode : "");

            return _str + "}";
        }
        static public string OpenApiOrderTypeToString(ProtoOAOrderType orderType)
        {
            switch (orderType)
            {
                case ProtoOAOrderType.OA_LIMIT:
                    return "LIMIT";
                case ProtoOAOrderType.OA_MARKET:
                    return "MARKET";
                case ProtoOAOrderType.OA_MARKET_RANGE:
                    return "MARKET RANGE";
                case ProtoOAOrderType.OA_PROTECTION:
                    return "PROTECTION";
                case ProtoOAOrderType.OA_STOP:
                    return "STOP";
                default:
                    return "unknown";
            }
        }
        static public string TradeSideToString(ProtoTradeSide tradeSide)
        {
            switch (tradeSide)
            {
                case ProtoTradeSide.BUY:
                    return "BUY";
                case ProtoTradeSide.SELL:
                    return "SELL";
                default:
                    return "unknown";
            }
        }
        static public string OpenApiOrderToString(ProtoOAOrder order)
        {
            var _str = "Order{orderId:" + order.orderId.ToString() + ", accountId:" + order.accountId + ", orderType:" + OpenApiOrderTypeToString(order.orderType);
            _str += ", tradeSide:" + TradeSideToString(order.tradeSide);
            _str += ", symbolName:" + order.symbolName + ", requestedVolume:" + order.requestedVolume.ToString() + ", executedVolume:" + order.executedVolume.ToString() + ", closingOrder:" +
                (order.closingOrder ? "TRUE" : "FALSE") +
                (order.executionPriceSpecified ? ", executionPrice:" + order.executionPrice.ToString() : "") +
                (order.limitPriceSpecified ? ", limitPrice:" + order.limitPrice.ToString() : "") +
                (order.stopPriceSpecified ? ", stopPrice:" + order.stopPrice.ToString() : "") +
                (order.stopLossPriceSpecified ? ", stopLossPrice:" + order.stopLossPrice.ToString() : "") +
                (order.takeProfitPriceSpecified ? ", takeProfitPrice:" + order.takeProfitPrice.ToString() : "") +
                (order.baseSlippagePriceSpecified ? ", baseSlippagePrice:" + order.baseSlippagePrice.ToString() : "") +
                (order.slippageInPipsSpecified ? ", slippageInPips:" + order.slippageInPips.ToString() : "") +
                (order.relativeStopLossInPipsSpecified ? ", relativeStopLossInPips:" + order.relativeStopLossInPips.ToString() : "") +
                (order.relativeTakeProfitInPipsSpecified ? ", relativeTakeProfitInPips:" + order.relativeTakeProfitInPips.ToString() : "") +
                (order.commissionSpecified ? ", commission:" + order.commission.ToString() : "") +
                (order.openTimestampSpecified ? ", openTimestamp:" + order.openTimestamp.ToString() : "") +
                (order.closeTimestampSpecified ? ", closeTimestamp:" + order.closeTimestamp.ToString() : "") +
                (order.expirationTimestampSpecified ? ", expirationTimestamp:" + order.expirationTimestamp.ToString() : "") +
                (order.channelSpecified ? ", channel:" + order.channel : "") +
                (order.commentSpecified ? ", comment:" + order.comment : "") +
                (order.closePositionDetails != null ? ", " + OpenApiClosePositionDetails(order.closePositionDetails) : "");

            return _str + "}";
        }
        static public string OpenApiPositionStatusToString(ProtoOAPositionStatus positionStatus)
        {
            switch (positionStatus)
            {
                case ProtoOAPositionStatus.OA_POSITION_STATUS_CLOSED:
                    return "CLOSED";
                case ProtoOAPositionStatus.OA_POSITION_STATUS_OPEN:
                    return "OPENED";
                default:
                    return "unknown";
            }
        }
        static public string OpenApiPositionToString(ProtoOAPosition position)
        {
            var _str = "Position{positionId:" + position.positionId.ToString() + ", positionStatus:" + OpenApiPositionStatusToString(position.positionStatus) +
                ", accountId:" + position.accountId.ToString();
            _str += ", tradeSide:" + TradeSideToString(position.tradeSide);
            _str += ", symbolName:" + position.symbolName + ", volume:" + position.volume.ToString() + ", entryPrice:" + position.entryPrice.ToString() + ", swap:" + position.swap.ToString() +
                ", commission:" + position.commission.ToString() + ", openTimestamp:" + position.openTimestamp.ToString() +
                (position.closeTimestampSpecified ? ", closeTimestamp:" + position.closeTimestamp.ToString() : "") +
                (position.stopLossPriceSpecified ? ", stopLossPrice:" + position.stopLossPrice.ToString() : "") +
                (position.takeProfitPriceSpecified ? ", takeProfitPrice:" + position.takeProfitPrice.ToString() : "") +
                (position.channelSpecified ? ", channel:" + position.channel : "") +
                (position.commentSpecified ? ", comment:" + position.comment : "");

            return _str + "}";
        }
        static public string OpenApiClosePositionDetails(ProtoOAClosePositionDetails closePositionDetails)
        {
            return "ClosePositionDetails{entryPrice:" + closePositionDetails.entryPrice.ToString() +
                ", profit:" + closePositionDetails.profit.ToString() +
                ", swap:" + closePositionDetails.swap.ToString() +
                ", commission:" + closePositionDetails.commission.ToString() +
                ", balance:" + closePositionDetails.balance.ToString() +
                (closePositionDetails.commentSpecified ? ", comment:" + closePositionDetails.comment : "") +
                (closePositionDetails.stopLossPriceSpecified ? ", stopLossPrice:" + closePositionDetails.stopLossPrice.ToString() : "") +
                (closePositionDetails.takeProfitPriceSpecified ? ", takeProfitPrice:" + closePositionDetails.takeProfitPrice.ToString() : "") +
                (closePositionDetails.quoteToDepositConversionRateSpecified ? ", quoteToDepositConversionRate:" + closePositionDetails.quoteToDepositConversionRate.ToString() : "") +
                ", closedVolume:" + closePositionDetails.closedVolume.ToString() +
                ", closedByStopOut:" + (closePositionDetails.closedByStopOut ? "TRUE" : "FALSE") +
                "}";
        }
        static public string ToString(ProtoMessage msg)
        {
            return ProtoMessageToString(msg);
        }
    }
}
