using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Attractions" )]
   [XmlType(TypeName =  "Attractions" , Namespace = "TravelAgency" )]
   [Serializable]
   public class SdtAttractions : GxSilentTrnSdt
   {
      public SdtAttractions( )
      {
      }

      public SdtAttractions( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV7AttractionId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV7AttractionId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AttractionId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Attractions");
         metadata.Set("BT", "Attractions");
         metadata.Set("PK", "[ \"AttractionId\" ]");
         metadata.Set("PKAssigned", "[ \"AttractionId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoryId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CountryId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"CountryId\",\"CityId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Attractionphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Attractionid_Z");
         state.Add("gxTpr_Attractionname_Z");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         state.Add("gxTpr_Cityid_Z");
         state.Add("gxTpr_Cityname_Z");
         state.Add("gxTpr_Attractionphoto_gxi_Z");
         state.Add("gxTpr_Categoryid_N");
         state.Add("gxTpr_Cityid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAttractions sdt;
         sdt = (SdtAttractions)(source);
         gxTv_SdtAttractions_Attractionid = sdt.gxTv_SdtAttractions_Attractionid ;
         gxTv_SdtAttractions_Attractionname = sdt.gxTv_SdtAttractions_Attractionname ;
         gxTv_SdtAttractions_Countryid = sdt.gxTv_SdtAttractions_Countryid ;
         gxTv_SdtAttractions_Countryname = sdt.gxTv_SdtAttractions_Countryname ;
         gxTv_SdtAttractions_Categoryid = sdt.gxTv_SdtAttractions_Categoryid ;
         gxTv_SdtAttractions_Categoryname = sdt.gxTv_SdtAttractions_Categoryname ;
         gxTv_SdtAttractions_Attractionphoto = sdt.gxTv_SdtAttractions_Attractionphoto ;
         gxTv_SdtAttractions_Attractionphoto_gxi = sdt.gxTv_SdtAttractions_Attractionphoto_gxi ;
         gxTv_SdtAttractions_Cityid = sdt.gxTv_SdtAttractions_Cityid ;
         gxTv_SdtAttractions_Cityname = sdt.gxTv_SdtAttractions_Cityname ;
         gxTv_SdtAttractions_Mode = sdt.gxTv_SdtAttractions_Mode ;
         gxTv_SdtAttractions_Initialized = sdt.gxTv_SdtAttractions_Initialized ;
         gxTv_SdtAttractions_Attractionid_Z = sdt.gxTv_SdtAttractions_Attractionid_Z ;
         gxTv_SdtAttractions_Attractionname_Z = sdt.gxTv_SdtAttractions_Attractionname_Z ;
         gxTv_SdtAttractions_Countryid_Z = sdt.gxTv_SdtAttractions_Countryid_Z ;
         gxTv_SdtAttractions_Countryname_Z = sdt.gxTv_SdtAttractions_Countryname_Z ;
         gxTv_SdtAttractions_Categoryid_Z = sdt.gxTv_SdtAttractions_Categoryid_Z ;
         gxTv_SdtAttractions_Categoryname_Z = sdt.gxTv_SdtAttractions_Categoryname_Z ;
         gxTv_SdtAttractions_Cityid_Z = sdt.gxTv_SdtAttractions_Cityid_Z ;
         gxTv_SdtAttractions_Cityname_Z = sdt.gxTv_SdtAttractions_Cityname_Z ;
         gxTv_SdtAttractions_Attractionphoto_gxi_Z = sdt.gxTv_SdtAttractions_Attractionphoto_gxi_Z ;
         gxTv_SdtAttractions_Categoryid_N = sdt.gxTv_SdtAttractions_Categoryid_N ;
         gxTv_SdtAttractions_Cityid_N = sdt.gxTv_SdtAttractions_Cityid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("AttractionId", gxTv_SdtAttractions_Attractionid, false, includeNonInitialized);
         AddObjectProperty("AttractionName", gxTv_SdtAttractions_Attractionname, false, includeNonInitialized);
         AddObjectProperty("CountryId", gxTv_SdtAttractions_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtAttractions_Countryname, false, includeNonInitialized);
         AddObjectProperty("CategoryId", gxTv_SdtAttractions_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryId_N", gxTv_SdtAttractions_Categoryid_N, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtAttractions_Categoryname, false, includeNonInitialized);
         AddObjectProperty("AttractionPhoto", gxTv_SdtAttractions_Attractionphoto, false, includeNonInitialized);
         AddObjectProperty("CityId", gxTv_SdtAttractions_Cityid, false, includeNonInitialized);
         AddObjectProperty("CityId_N", gxTv_SdtAttractions_Cityid_N, false, includeNonInitialized);
         AddObjectProperty("CityName", gxTv_SdtAttractions_Cityname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("AttractionPhoto_GXI", gxTv_SdtAttractions_Attractionphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtAttractions_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAttractions_Initialized, false, includeNonInitialized);
            AddObjectProperty("AttractionId_Z", gxTv_SdtAttractions_Attractionid_Z, false, includeNonInitialized);
            AddObjectProperty("AttractionName_Z", gxTv_SdtAttractions_Attractionname_Z, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtAttractions_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtAttractions_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtAttractions_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtAttractions_Categoryname_Z, false, includeNonInitialized);
            AddObjectProperty("CityId_Z", gxTv_SdtAttractions_Cityid_Z, false, includeNonInitialized);
            AddObjectProperty("CityName_Z", gxTv_SdtAttractions_Cityname_Z, false, includeNonInitialized);
            AddObjectProperty("AttractionPhoto_GXI_Z", gxTv_SdtAttractions_Attractionphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryId_N", gxTv_SdtAttractions_Categoryid_N, false, includeNonInitialized);
            AddObjectProperty("CityId_N", gxTv_SdtAttractions_Cityid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAttractions sdt )
      {
         if ( sdt.IsDirty("AttractionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionid = sdt.gxTv_SdtAttractions_Attractionid ;
         }
         if ( sdt.IsDirty("AttractionName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionname = sdt.gxTv_SdtAttractions_Attractionname ;
         }
         if ( sdt.IsDirty("CountryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryid = sdt.gxTv_SdtAttractions_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryname = sdt.gxTv_SdtAttractions_Countryname ;
         }
         if ( sdt.IsDirty("CategoryId") )
         {
            gxTv_SdtAttractions_Categoryid_N = (short)(sdt.gxTv_SdtAttractions_Categoryid_N);
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryid = sdt.gxTv_SdtAttractions_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryname = sdt.gxTv_SdtAttractions_Categoryname ;
         }
         if ( sdt.IsDirty("AttractionPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionphoto = sdt.gxTv_SdtAttractions_Attractionphoto ;
         }
         if ( sdt.IsDirty("AttractionPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionphoto_gxi = sdt.gxTv_SdtAttractions_Attractionphoto_gxi ;
         }
         if ( sdt.IsDirty("CityId") )
         {
            gxTv_SdtAttractions_Cityid_N = (short)(sdt.gxTv_SdtAttractions_Cityid_N);
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityid = sdt.gxTv_SdtAttractions_Cityid ;
         }
         if ( sdt.IsDirty("CityName") )
         {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityname = sdt.gxTv_SdtAttractions_Cityname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AttractionId" )]
      [  XmlElement( ElementName = "AttractionId"   )]
      public short gxTpr_Attractionid
      {
         get {
            return gxTv_SdtAttractions_Attractionid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAttractions_Attractionid != value )
            {
               gxTv_SdtAttractions_Mode = "INS";
               this.gxTv_SdtAttractions_Attractionid_Z_SetNull( );
               this.gxTv_SdtAttractions_Attractionname_Z_SetNull( );
               this.gxTv_SdtAttractions_Countryid_Z_SetNull( );
               this.gxTv_SdtAttractions_Countryname_Z_SetNull( );
               this.gxTv_SdtAttractions_Categoryid_Z_SetNull( );
               this.gxTv_SdtAttractions_Categoryname_Z_SetNull( );
               this.gxTv_SdtAttractions_Cityid_Z_SetNull( );
               this.gxTv_SdtAttractions_Cityname_Z_SetNull( );
               this.gxTv_SdtAttractions_Attractionphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtAttractions_Attractionid = value;
            SetDirty("Attractionid");
         }

      }

      [  SoapElement( ElementName = "AttractionName" )]
      [  XmlElement( ElementName = "AttractionName"   )]
      public string gxTpr_Attractionname
      {
         get {
            return gxTv_SdtAttractions_Attractionname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionname = value;
            SetDirty("Attractionname");
         }

      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtAttractions_Countryid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtAttractions_Countryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtAttractions_Categoryid ;
         }

         set {
            gxTv_SdtAttractions_Categoryid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryid = value;
            SetDirty("Categoryid");
         }

      }

      public void gxTv_SdtAttractions_Categoryid_SetNull( )
      {
         gxTv_SdtAttractions_Categoryid_N = 1;
         gxTv_SdtAttractions_Categoryid = 0;
         SetDirty("Categoryid");
         return  ;
      }

      public bool gxTv_SdtAttractions_Categoryid_IsNull( )
      {
         return (gxTv_SdtAttractions_Categoryid_N==1) ;
      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtAttractions_Categoryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryname = value;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "AttractionPhoto" )]
      [  XmlElement( ElementName = "AttractionPhoto"   )]
      [GxUpload()]
      public string gxTpr_Attractionphoto
      {
         get {
            return gxTv_SdtAttractions_Attractionphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionphoto = value;
            SetDirty("Attractionphoto");
         }

      }

      [  SoapElement( ElementName = "AttractionPhoto_GXI" )]
      [  XmlElement( ElementName = "AttractionPhoto_GXI"   )]
      public string gxTpr_Attractionphoto_gxi
      {
         get {
            return gxTv_SdtAttractions_Attractionphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionphoto_gxi = value;
            SetDirty("Attractionphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "CityId" )]
      [  XmlElement( ElementName = "CityId"   )]
      public short gxTpr_Cityid
      {
         get {
            return gxTv_SdtAttractions_Cityid ;
         }

         set {
            gxTv_SdtAttractions_Cityid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityid = value;
            SetDirty("Cityid");
         }

      }

      public void gxTv_SdtAttractions_Cityid_SetNull( )
      {
         gxTv_SdtAttractions_Cityid_N = 1;
         gxTv_SdtAttractions_Cityid = 0;
         SetDirty("Cityid");
         return  ;
      }

      public bool gxTv_SdtAttractions_Cityid_IsNull( )
      {
         return (gxTv_SdtAttractions_Cityid_N==1) ;
      }

      [  SoapElement( ElementName = "CityName" )]
      [  XmlElement( ElementName = "CityName"   )]
      public string gxTpr_Cityname
      {
         get {
            return gxTv_SdtAttractions_Cityname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityname = value;
            SetDirty("Cityname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAttractions_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAttractions_Mode_SetNull( )
      {
         gxTv_SdtAttractions_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAttractions_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAttractions_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAttractions_Initialized_SetNull( )
      {
         gxTv_SdtAttractions_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAttractions_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionId_Z" )]
      [  XmlElement( ElementName = "AttractionId_Z"   )]
      public short gxTpr_Attractionid_Z
      {
         get {
            return gxTv_SdtAttractions_Attractionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionid_Z = value;
            SetDirty("Attractionid_Z");
         }

      }

      public void gxTv_SdtAttractions_Attractionid_Z_SetNull( )
      {
         gxTv_SdtAttractions_Attractionid_Z = 0;
         SetDirty("Attractionid_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Attractionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionName_Z" )]
      [  XmlElement( ElementName = "AttractionName_Z"   )]
      public string gxTpr_Attractionname_Z
      {
         get {
            return gxTv_SdtAttractions_Attractionname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionname_Z = value;
            SetDirty("Attractionname_Z");
         }

      }

      public void gxTv_SdtAttractions_Attractionname_Z_SetNull( )
      {
         gxTv_SdtAttractions_Attractionname_Z = "";
         SetDirty("Attractionname_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Attractionname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtAttractions_Countryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtAttractions_Countryid_Z_SetNull( )
      {
         gxTv_SdtAttractions_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtAttractions_Countryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtAttractions_Countryname_Z_SetNull( )
      {
         gxTv_SdtAttractions_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtAttractions_Categoryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryid_Z = value;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtAttractions_Categoryid_Z_SetNull( )
      {
         gxTv_SdtAttractions_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtAttractions_Categoryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryname_Z = value;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtAttractions_Categoryname_Z_SetNull( )
      {
         gxTv_SdtAttractions_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Categoryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CityId_Z" )]
      [  XmlElement( ElementName = "CityId_Z"   )]
      public short gxTpr_Cityid_Z
      {
         get {
            return gxTv_SdtAttractions_Cityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityid_Z = value;
            SetDirty("Cityid_Z");
         }

      }

      public void gxTv_SdtAttractions_Cityid_Z_SetNull( )
      {
         gxTv_SdtAttractions_Cityid_Z = 0;
         SetDirty("Cityid_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Cityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CityName_Z" )]
      [  XmlElement( ElementName = "CityName_Z"   )]
      public string gxTpr_Cityname_Z
      {
         get {
            return gxTv_SdtAttractions_Cityname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityname_Z = value;
            SetDirty("Cityname_Z");
         }

      }

      public void gxTv_SdtAttractions_Cityname_Z_SetNull( )
      {
         gxTv_SdtAttractions_Cityname_Z = "";
         SetDirty("Cityname_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Cityname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AttractionPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "AttractionPhoto_GXI_Z"   )]
      public string gxTpr_Attractionphoto_gxi_Z
      {
         get {
            return gxTv_SdtAttractions_Attractionphoto_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Attractionphoto_gxi_Z = value;
            SetDirty("Attractionphoto_gxi_Z");
         }

      }

      public void gxTv_SdtAttractions_Attractionphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtAttractions_Attractionphoto_gxi_Z = "";
         SetDirty("Attractionphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtAttractions_Attractionphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_N" )]
      [  XmlElement( ElementName = "CategoryId_N"   )]
      public short gxTpr_Categoryid_N
      {
         get {
            return gxTv_SdtAttractions_Categoryid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Categoryid_N = value;
            SetDirty("Categoryid_N");
         }

      }

      public void gxTv_SdtAttractions_Categoryid_N_SetNull( )
      {
         gxTv_SdtAttractions_Categoryid_N = 0;
         SetDirty("Categoryid_N");
         return  ;
      }

      public bool gxTv_SdtAttractions_Categoryid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CityId_N" )]
      [  XmlElement( ElementName = "CityId_N"   )]
      public short gxTpr_Cityid_N
      {
         get {
            return gxTv_SdtAttractions_Cityid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAttractions_Cityid_N = value;
            SetDirty("Cityid_N");
         }

      }

      public void gxTv_SdtAttractions_Cityid_N_SetNull( )
      {
         gxTv_SdtAttractions_Cityid_N = 0;
         SetDirty("Cityid_N");
         return  ;
      }

      public bool gxTv_SdtAttractions_Cityid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtAttractions_Attractionname = "";
         gxTv_SdtAttractions_Countryname = "";
         gxTv_SdtAttractions_Categoryname = "";
         gxTv_SdtAttractions_Attractionphoto = "";
         gxTv_SdtAttractions_Attractionphoto_gxi = "";
         gxTv_SdtAttractions_Cityname = "";
         gxTv_SdtAttractions_Mode = "";
         gxTv_SdtAttractions_Attractionname_Z = "";
         gxTv_SdtAttractions_Countryname_Z = "";
         gxTv_SdtAttractions_Categoryname_Z = "";
         gxTv_SdtAttractions_Cityname_Z = "";
         gxTv_SdtAttractions_Attractionphoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "attractions", "GeneXus.Programs.attractions_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtAttractions_Attractionid ;
      private short sdtIsNull ;
      private short gxTv_SdtAttractions_Countryid ;
      private short gxTv_SdtAttractions_Categoryid ;
      private short gxTv_SdtAttractions_Cityid ;
      private short gxTv_SdtAttractions_Initialized ;
      private short gxTv_SdtAttractions_Attractionid_Z ;
      private short gxTv_SdtAttractions_Countryid_Z ;
      private short gxTv_SdtAttractions_Categoryid_Z ;
      private short gxTv_SdtAttractions_Cityid_Z ;
      private short gxTv_SdtAttractions_Categoryid_N ;
      private short gxTv_SdtAttractions_Cityid_N ;
      private string gxTv_SdtAttractions_Attractionname ;
      private string gxTv_SdtAttractions_Countryname ;
      private string gxTv_SdtAttractions_Categoryname ;
      private string gxTv_SdtAttractions_Cityname ;
      private string gxTv_SdtAttractions_Mode ;
      private string gxTv_SdtAttractions_Attractionname_Z ;
      private string gxTv_SdtAttractions_Countryname_Z ;
      private string gxTv_SdtAttractions_Categoryname_Z ;
      private string gxTv_SdtAttractions_Cityname_Z ;
      private string gxTv_SdtAttractions_Attractionphoto_gxi ;
      private string gxTv_SdtAttractions_Attractionphoto_gxi_Z ;
      private string gxTv_SdtAttractions_Attractionphoto ;
   }

   [DataContract(Name = @"Attractions", Namespace = "TravelAgency")]
   [GxJsonSerialization("default")]
   public class SdtAttractions_RESTInterface : GxGenericCollectionItem<SdtAttractions>
   {
      public SdtAttractions_RESTInterface( ) : base()
      {
      }

      public SdtAttractions_RESTInterface( SdtAttractions psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AttractionId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Attractionid
      {
         get {
            return sdt.gxTpr_Attractionid ;
         }

         set {
            sdt.gxTpr_Attractionid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AttractionName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Attractionname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Attractionname) ;
         }

         set {
            sdt.gxTpr_Attractionname = value;
         }

      }

      [DataMember( Name = "CountryId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Countryid
      {
         get {
            return sdt.gxTpr_Countryid ;
         }

         set {
            sdt.gxTpr_Countryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CountryName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Countryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Countryname) ;
         }

         set {
            sdt.gxTpr_Countryname = value;
         }

      }

      [DataMember( Name = "CategoryId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoryid
      {
         get {
            return sdt.gxTpr_Categoryid ;
         }

         set {
            sdt.gxTpr_Categoryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoryName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Categoryname) ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
         }

      }

      [DataMember( Name = "AttractionPhoto" , Order = 6 )]
      [GxUpload()]
      public string gxTpr_Attractionphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Attractionphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Attractionphoto) : StringUtil.RTrim( sdt.gxTpr_Attractionphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Attractionphoto = value;
         }

      }

      [DataMember( Name = "CityId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Cityid
      {
         get {
            return sdt.gxTpr_Cityid ;
         }

         set {
            sdt.gxTpr_Cityid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CityName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Cityname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Cityname) ;
         }

         set {
            sdt.gxTpr_Cityname = value;
         }

      }

      public SdtAttractions sdt
      {
         get {
            return (SdtAttractions)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtAttractions() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Attractions", Namespace = "TravelAgency")]
   [GxJsonSerialization("default")]
   public class SdtAttractions_RESTLInterface : GxGenericCollectionItem<SdtAttractions>
   {
      public SdtAttractions_RESTLInterface( ) : base()
      {
      }

      public SdtAttractions_RESTLInterface( SdtAttractions psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AttractionName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Attractionname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Attractionname) ;
         }

         set {
            sdt.gxTpr_Attractionname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtAttractions sdt
      {
         get {
            return (SdtAttractions)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtAttractions() ;
         }
      }

   }

}
