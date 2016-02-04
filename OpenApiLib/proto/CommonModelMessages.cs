//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Option: missing-value detection (*Specified/ShouldSerialize*/Reset*) enabled
    
// Option: light framework (CF/Silverlight) enabled
    
// Generated from: CommonModelMessages.proto
namespace OpenApiLib.Proto
{
  [global::ProtoBuf.ProtoContract(Name=@"ProtoIntRange")]
  public partial class ProtoIntRange : global::ProtoBuf.IExtensible
  {
    public ProtoIntRange() {}
    
    private int? _from;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int from
    {
      get { return _from?? default(int); }
      set { _from = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool fromSpecified
    {
      get { return this._from != null; }
      set { if (value == (this._from== null)) this._from = value ? this.from : (int?)null; }
    }
    private bool ShouldSerializefrom() { return fromSpecified; }
    private void Resetfrom() { fromSpecified = false; }
    
    private int? _to;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int to
    {
      get { return _to?? default(int); }
      set { _to = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool toSpecified
    {
      get { return this._to != null; }
      set { if (value == (this._to== null)) this._to = value ? this.to : (int?)null; }
    }
    private bool ShouldSerializeto() { return toSpecified; }
    private void Resetto() { toSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::ProtoBuf.ProtoContract(Name=@"ProtoLongRange")]
  public partial class ProtoLongRange : global::ProtoBuf.IExtensible
  {
    public ProtoLongRange() {}
    
    private long? _from;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long from
    {
      get { return _from?? default(long); }
      set { _from = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool fromSpecified
    {
      get { return this._from != null; }
      set { if (value == (this._from== null)) this._from = value ? this.from : (long?)null; }
    }
    private bool ShouldSerializefrom() { return fromSpecified; }
    private void Resetfrom() { fromSpecified = false; }
    
    private long? _to;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public long to
    {
      get { return _to?? default(long); }
      set { _to = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool toSpecified
    {
      get { return this._to != null; }
      set { if (value == (this._to== null)) this._to = value ? this.to : (long?)null; }
    }
    private bool ShouldSerializeto() { return toSpecified; }
    private void Resetto() { toSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::ProtoBuf.ProtoContract(Name=@"ProtoDoubleRange")]
  public partial class ProtoDoubleRange : global::ProtoBuf.IExtensible
  {
    public ProtoDoubleRange() {}
    
    private double? _from;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"from", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double from
    {
      get { return _from?? default(double); }
      set { _from = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool fromSpecified
    {
      get { return this._from != null; }
      set { if (value == (this._from== null)) this._from = value ? this.from : (double?)null; }
    }
    private bool ShouldSerializefrom() { return fromSpecified; }
    private void Resetfrom() { fromSpecified = false; }
    
    private double? _to;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"to", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public double to
    {
      get { return _to?? default(double); }
      set { _to = value; }
    }
    [global::System.Xml.Serialization.XmlIgnore]
    
    public bool toSpecified
    {
      get { return this._to != null; }
      set { if (value == (this._to== null)) this._to = value ? this.to : (double?)null; }
    }
    private bool ShouldSerializeto() { return toSpecified; }
    private void Resetto() { toSpecified = false; }
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"ProtoPayloadType")]
    public enum ProtoPayloadType
    {
	  [global::ProtoBuf.ProtoEnum(Name=@"PROTO_MESSAGE", Value=5)]
	  PROTO_MESSAGE = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_RES", Value=50)]
      ERROR_RES = 50,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HEARTBEAT_EVENT", Value=51)]
      HEARTBEAT_EVENT = 51,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PING_REQ", Value=52)]
      PING_REQ = 52,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PING_RES", Value=53)]
      PING_RES = 53
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"ProtoErrorCode")]
    public enum ProtoErrorCode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"UNKNOWN_ERROR", Value=1)]
      UNKNOWN_ERROR = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"UNSUPPORTED_MESSAGE", Value=2)]
      UNSUPPORTED_MESSAGE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INVALID_REQUEST", Value=3)]
      INVALID_REQUEST = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"WRONG_PASSWORD", Value=4)]
      WRONG_PASSWORD = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TIMEOUT_ERROR", Value=5)]
      TIMEOUT_ERROR = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ENTITY_NOT_FOUND", Value=6)]
      ENTITY_NOT_FOUND = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CANT_ROUTE_REQUEST", Value=7)]
      CANT_ROUTE_REQUEST = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"FRAME_TOO_LONG", Value=8)]
      FRAME_TOO_LONG = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MARKET_CLOSED", Value=9)]
      MARKET_CLOSED = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CONCURRENT_MODIFICATION", Value=10)]
      CONCURRENT_MODIFICATION = 10
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"ProtoTradeSide")]
    public enum ProtoTradeSide
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"BUY", Value=1)]
      BUY = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SELL", Value=2)]
      SELL = 2
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"ProtoQuoteType")]
    public enum ProtoQuoteType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"BID", Value=1)]
      BID = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ASK", Value=2)]
      ASK = 2
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"ProtoTimeInForce")]
    public enum ProtoTimeInForce
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"GOOD_TILL_DATE", Value=1)]
      GOOD_TILL_DATE = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GOOD_TILL_CANCEL", Value=2)]
      GOOD_TILL_CANCEL = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IMMEDIATE_OR_CANCEL", Value=3)]
      IMMEDIATE_OR_CANCEL = 3
    }
  
}