//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : PV_ProyectoFinal
	/// Data Source    : DENNIS\SQLEXPRESS
	/// Server Version : 14.00.1000
	/// </summary>
	public partial class PvProyectoFinalDB : LinqToDB.Data.DataConnection
	{
		public ITable<Bitacora>    Bitacoras    { get { return this.GetTable<Bitacora>(); } }
		public ITable<Habitacion>  Habitacions  { get { return this.GetTable<Habitacion>(); } }
		public ITable<Hotel>       Hotels       { get { return this.GetTable<Hotel>(); } }
		public ITable<Persona>     Personas     { get { return this.GetTable<Persona>(); } }
		public ITable<Reservacion> Reservacions { get { return this.GetTable<Reservacion>(); } }

		public PvProyectoFinalDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions<PvProyectoFinalDB> options)
			: base(options.Options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Bitacora")]
	public partial class Bitacora
	{
		[Column("idBitacora"),      PrimaryKey,  Identity] public int      IdBitacora      { get; set; } // int
		[Column("idReservacion"),   NotNull              ] public int      IdReservacion   { get; set; } // int
		[Column("idPersona"),       NotNull              ] public int      IdPersona       { get; set; } // int
		[Column("accionRealizada"),    Nullable          ] public string   AccionRealizada { get; set; } // nvarchar(100)
		[Column("fechaDeLaAccion"), NotNull              ] public DateTime FechaDeLaAccion { get; set; } // datetime

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		/// <summary>
		/// FK_Bitacora_Reservacion (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=false)]
		public Reservacion Reservacion { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Habitacion")]
	public partial class Habitacion
	{
		[Column("idHabitacion"),     PrimaryKey, Identity] public int    IdHabitacion     { get; set; } // int
		[Column("idHotel"),          NotNull             ] public int    IdHotel          { get; set; } // int
		[Column("numeroHabitacion"), NotNull             ] public string NumeroHabitacion { get; set; } // varchar(10)
		[Column("capacidadMaxima"),  NotNull             ] public int    CapacidadMaxima  { get; set; } // int
		[Column("descripcion"),      NotNull             ] public string Descripcion      { get; set; } // varchar(500)
		[Column("estado"),           NotNull             ] public char   Estado           { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel (dbo.Hotel)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=false)]
		public Hotel Hotel { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Hotel")]
	public partial class Hotel
	{
		[Column("idHotel"),            PrimaryKey,  Identity] public int     IdHotel            { get; set; } // int
		[Column("nombre"),             NotNull              ] public string  Nombre             { get; set; } // varchar(150)
		[Column("direccion"),             Nullable          ] public string  Direccion          { get; set; } // varchar(500)
		[Column("costoPorCadaAdulto"), NotNull              ] public decimal CostoPorCadaAdulto { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),  NotNull              ] public decimal CostoPorCadaNinho  { get; set; } // numeric(10, 2)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel_BackReference (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=true)]
		public IEnumerable<Habitacion> Habitacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Persona")]
	public partial class Persona
	{
		[Column("idPersona"),      PrimaryKey, Identity] public int    IdPersona      { get; set; } // int
		[Column("nombreCompleto"), NotNull             ] public string NombreCompleto { get; set; } // varchar(250)
		[Column("email"),          NotNull             ] public string Email          { get; set; } // varchar(150)
		[Column("clave"),          NotNull             ] public string Clave          { get; set; } // varchar(15)
		[Column("esEmpleado"),     NotNull             ] public bool   EsEmpleado     { get; set; } // bit
		[Column("estado"),         NotNull             ] public char   Estado         { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Reservacion")]
	public partial class Reservacion
	{
		[Column("idReservacion"),        PrimaryKey,  Identity] public int       IdReservacion        { get; set; } // int
		[Column("idPersona"),            NotNull              ] public int       IdPersona            { get; set; } // int
		[Column("idHabitacion"),         NotNull              ] public int       IdHabitacion         { get; set; } // int
		[Column("fechaEntrada"),         NotNull              ] public DateTime  FechaEntrada         { get; set; } // datetime
		[Column("fechaSalida"),          NotNull              ] public DateTime  FechaSalida          { get; set; } // datetime
		[Column("numeroAdultos"),        NotNull              ] public int       NumeroAdultos        { get; set; } // int
		[Column("numeroNinhos"),         NotNull              ] public int       NumeroNinhos         { get; set; } // int
		[Column("totalDiasReservacion"), NotNull              ] public int       TotalDiasReservacion { get; set; } // int
		[Column("costoPorCadaAdulto"),   NotNull              ] public decimal   CostoPorCadaAdulto   { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),    NotNull              ] public decimal   CostoPorCadaNinho    { get; set; } // numeric(10, 2)
		[Column("costoTotal"),           NotNull              ] public decimal   CostoTotal           { get; set; } // numeric(14, 2)
		[Column("fechaCreacion"),        NotNull              ] public DateTime  FechaCreacion        { get; set; } // datetime
		[Column("fechaModificacion"),       Nullable          ] public DateTime? FechaModificacion    { get; set; } // datetime
		[Column("estado"),               NotNull              ] public char      Estado               { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Reservacion_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=false)]
		public Habitacion Habitacion { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		#endregion
	}

	public static partial class PvProyectoFinalDBStoredProcedures
	{
		#region SpActualizarReservacion

		public static int SpActualizarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idHabitacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, int? @totalDiasReservacion, decimal? @costoPorCadaAdulto, decimal? @costoPorCadaNinho, decimal? @costoTotal, DateTime? @fechaModificacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion",        @idReservacion,        LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",         @idHabitacion,         LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",         @fechaEntrada,         LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",          @fechaSalida,          LinqToDB.DataType.Date),
				new DataParameter("@numeroAdultos",        @numeroAdultos,        LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",         @numeroNinhos,         LinqToDB.DataType.Int32),
				new DataParameter("@totalDiasReservacion", @totalDiasReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@costoPorCadaAdulto",   @costoPorCadaAdulto,   LinqToDB.DataType.Decimal),
				new DataParameter("@costoPorCadaNinho",    @costoPorCadaNinho,    LinqToDB.DataType.Decimal),
				new DataParameter("@costoTotal",           @costoTotal,           LinqToDB.DataType.Decimal),
				new DataParameter("@fechaModificacion",    @fechaModificacion,    LinqToDB.DataType.DateTime)
			};

			return dataConnection.ExecuteProc("[dbo].[SpActualizarReservacion]", parameters);
		}

		#endregion

		#region SpBuscarHabitacionPorId

		public static IEnumerable<SpBuscarHabitacionPorIdResult> SpBuscarHabitacionPorId(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpBuscarHabitacionPorIdResult>("[dbo].[sp_BuscarHabitacionPorId]", parameters);
		}

		public partial class SpBuscarHabitacionPorIdResult
		{
            internal string Estado;

            [Column("idHabitacion")    ] public int    IdHabitacion     { get; set; }
			[Column("numeroHabitacion")] public string NumeroHabitacion { get; set; }
			[Column("capacidadMaxima") ] public int    CapacidadMaxima  { get; set; }
			[Column("descripcion")     ] public string Descripcion      { get; set; }
			                             public string NombreHotel      { get; set; }
		}

		#endregion

		#region SpCancelarReservacion

		public static IEnumerable<SpCancelarReservacionResult> SpCancelarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCancelarReservacionResult>("[dbo].[sp_CancelarReservacion]", parameters);
		}

		public partial class SpCancelarReservacionResult
		{
			[Column("mensaje")] public string Mensaje { get; set; }
		}

		#endregion

		#region SpConsultarBitacora

		public static IEnumerable<Bitacora> SpConsultarBitacora(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Bitacora>("[dbo].[SpConsultarBitacora]");
		}

		#endregion

		#region SpConsultarDisponibilidadHabitaciones

		public static IEnumerable<SpConsultarDisponibilidadHabitacionesResult> SpConsultarDisponibilidadHabitaciones(this PvProyectoFinalDB dataConnection, int? @idHotel, int? @numeroAdultos, int? @numeroNinhos)
		{
			var parameters = new []
			{
				new DataParameter("@idHotel",       @idHotel,       LinqToDB.DataType.Int32),
				new DataParameter("@numeroAdultos", @numeroAdultos, LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",  @numeroNinhos,  LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarDisponibilidadHabitacionesResult>("[dbo].[sp_ConsultarDisponibilidadHabitaciones]", parameters);
		}

		public partial class SpConsultarDisponibilidadHabitacionesResult
		{
			[Column("idHabitacion")    ] public int    IdHabitacion     { get; set; }
			[Column("numeroHabitacion")] public string NumeroHabitacion { get; set; }
		}

		#endregion

		#region SpConsultarHoteles

		public static IEnumerable<Hotel> SpConsultarHoteles(this PvProyectoFinalDB dataConnection, string @FiltroNombre, decimal? @CostoAdultoMin, decimal? @CostoAdultoMax, decimal? @CostoNinhoMin, decimal? @CostoNinhoMax)
		{
			var parameters = new []
			{
				new DataParameter("@FiltroNombre",   @FiltroNombre,   LinqToDB.DataType.VarChar)
				{
					Size = 150
				},
				new DataParameter("@CostoAdultoMin", @CostoAdultoMin, LinqToDB.DataType.Decimal),
				new DataParameter("@CostoAdultoMax", @CostoAdultoMax, LinqToDB.DataType.Decimal),
				new DataParameter("@CostoNinhoMin",  @CostoNinhoMin,  LinqToDB.DataType.Decimal),
				new DataParameter("@CostoNinhoMax",  @CostoNinhoMax,  LinqToDB.DataType.Decimal)
			};

			return dataConnection.QueryProc<Hotel>("[dbo].[SpConsultarHoteles]", parameters);
		}

		#endregion

		#region SpConsultarReservacionesCliente

		public static IEnumerable<SpConsultarReservacionesClienteResult> SpConsultarReservacionesCliente(this PvProyectoFinalDB dataConnection, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona", @idPersona, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarReservacionesClienteResult>("[dbo].[sp_ConsultarReservacionesCliente]", parameters);
		}

		public partial class SpConsultarReservacionesClienteResult
		{
			[Column("idReservacion")     ] public int      IdReservacion      { get; set; }
			                               public string   Cliente            { get; set; }
			                               public string   Hotel              { get; set; }
			[Column("fechaEntrada")      ] public DateTime FechaEntrada       { get; set; }
			[Column("fechaSalida")       ] public DateTime FechaSalida        { get; set; }
			[Column("numeroAdultos")     ] public int      NumeroAdultos      { get; set; }
			[Column("numeroNinhos")      ] public int      NumeroNinhos       { get; set; }
			[Column("costoPorCadaAdulto")] public decimal  CostoPorCadaAdulto { get; set; }
			[Column("costoPorCadaNinho") ] public decimal  CostoPorCadaNinho  { get; set; }
			[Column("costoTotal")        ] public decimal  CostoTotal         { get; set; }
			                               public string   Estado             { get; set; }
		}

		#endregion

		#region SpConsultarReservacionesEmpleado

		public static IEnumerable<SpConsultarReservacionesEmpleadoResult> SpConsultarReservacionesEmpleado(this PvProyectoFinalDB dataConnection, int? @idPersona, string @nombreCliente, DateTime? @fechaEntrada, DateTime? @fechaSalida)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32),
				new DataParameter("@nombreCliente", @nombreCliente, LinqToDB.DataType.NVarChar)
				{
					Size = 100
				},
				new DataParameter("@fechaEntrada",  @fechaEntrada,  LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",   @fechaSalida,   LinqToDB.DataType.Date)
			};

			return dataConnection.QueryProc<SpConsultarReservacionesEmpleadoResult>("[dbo].[sp_ConsultarReservacionesEmpleado]", parameters);
		}

		public partial class SpConsultarReservacionesEmpleadoResult
		{
			public int      Id                { get; set; }
			public string   NombreUsuario     { get; set; }
			public string   Correo            { get; set; }
			public DateTime FechaEntrada      { get; set; }
			public DateTime FechaSalida       { get; set; }
			public string   NombreHotel       { get; set; }
			public string   NumeroHabitacion  { get; set; }
			public decimal  CostoTotal        { get; set; }
			public string   EstadoReservacion { get; set; }
		}

		#endregion

		#region SpConsultarReservacionPorId

		public static IEnumerable<SpConsultarReservacionPorIdResult> SpConsultarReservacionPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarReservacionPorIdResult>("[dbo].[spConsultarReservacionPorId]", parameters);
		}

		public partial class SpConsultarReservacionPorIdResult
		{
			public int      IdReservacion         { get; set; }
			public DateTime FechaEntrada          { get; set; }
			public DateTime FechaSalida           { get; set; }
			public int      NumeroAdultos         { get; set; }
			public int      NumeroNinhos          { get; set; }
			public int      IdHabitacion          { get; set; }
			public decimal  CostoTotal            { get; set; }
			public string   NumeroHabitacion      { get; set; }
			public string   DescripcionHabitacion { get; set; }
			public string   NombrePersona         { get; set; }
		}

		#endregion

		#region SpCrearHabitacion

		public static int SpCrearHabitacion(this PvProyectoFinalDB dataConnection, int? @idHotel, string @numeroHabitacion, char? @estado, int? @capacidadMaxima, string @descripcion)
		{
			var parameters = new []
			{
				new DataParameter("@idHotel",          @idHotel,          LinqToDB.DataType.Int32),
				new DataParameter("@numeroHabitacion", @numeroHabitacion, LinqToDB.DataType.VarChar)
				{
					Size = 50
				},
				new DataParameter("@estado",           @estado,           LinqToDB.DataType.Char)
				{
					Size = 1
				},
				new DataParameter("@capacidadMaxima",  @capacidadMaxima,  LinqToDB.DataType.Int32),
				new DataParameter("@descripcion",      @descripcion,      LinqToDB.DataType.VarChar)
				{
					Size = 255
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_CrearHabitacion]", parameters);
		}

		#endregion

		#region SpCrearReservacion

		public static int SpCrearReservacion(this PvProyectoFinalDB dataConnection, int? @idPersona, int? @idHabitacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, decimal? @costoPorCadaAdulto, decimal? @costoPorCadaNinho, int? @totalDiasReservacion, decimal? @costoTotal)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",            @idPersona,            LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",         @idHabitacion,         LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",         @fechaEntrada,         LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",          @fechaSalida,          LinqToDB.DataType.Date),
				new DataParameter("@numeroAdultos",        @numeroAdultos,        LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",         @numeroNinhos,         LinqToDB.DataType.Int32),
				new DataParameter("@costoPorCadaAdulto",   @costoPorCadaAdulto,   LinqToDB.DataType.Decimal),
				new DataParameter("@costoPorCadaNinho",    @costoPorCadaNinho,    LinqToDB.DataType.Decimal),
				new DataParameter("@totalDiasReservacion", @totalDiasReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@costoTotal",           @costoTotal,           LinqToDB.DataType.Decimal)
			};

			return dataConnection.ExecuteProc("[dbo].[sp_CrearReservacion]", parameters);
		}

		#endregion

		#region SpEditarHabitacion

		public static int SpEditarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion, int? @capacidadMaxima, string @descripcion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion",    @idHabitacion,    LinqToDB.DataType.Int32),
				new DataParameter("@capacidadMaxima", @capacidadMaxima, LinqToDB.DataType.Int32),
				new DataParameter("@descripcion",     @descripcion,     LinqToDB.DataType.VarChar)
				{
					Size = 500
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_EditarHabitacion]", parameters);
		}

		#endregion

		#region SpEditarReservacionPorId

		public static IEnumerable<SpEditarReservacionPorIdResult> SpEditarReservacionPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, int? @idHabitacion, decimal? @costoTotal)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",  @fechaEntrada,  LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",   @fechaSalida,   LinqToDB.DataType.Date),
				new DataParameter("@numeroAdultos", @numeroAdultos, LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",  @numeroNinhos,  LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",  @idHabitacion,  LinqToDB.DataType.Int32),
				new DataParameter("@costoTotal",    @costoTotal,    LinqToDB.DataType.Decimal)
			};

			return dataConnection.QueryProc<SpEditarReservacionPorIdResult>("[dbo].[sp_EditarReservacionPorId]", parameters);
		}

		public partial class SpEditarReservacionPorIdResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region SpEliminarReservacion

		public static int SpEliminarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[SpEliminarReservacion]", parameters);
		}

		#endregion

		#region SpEliminarReservacionPorId

		public static IEnumerable<SpEliminarReservacionPorIdResult> SpEliminarReservacionPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpEliminarReservacionPorIdResult>("[dbo].[SpEliminarReservacionPorId]", parameters);
		}

		public partial class SpEliminarReservacionPorIdResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region SpInactivarHabitacion

		public static int SpInactivarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[sp_InactivarHabitacion]", parameters);
		}

		#endregion

		#region SpInsertarBitacora

		public static int SpInsertarBitacora(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona, string @accionRealizada, DateTime? @fechaDeLaAccion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion",   @idReservacion,   LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",       @idPersona,       LinqToDB.DataType.Int32),
				new DataParameter("@accionRealizada", @accionRealizada, LinqToDB.DataType.NVarChar)
				{
					Size = 100
				},
				new DataParameter("@fechaDeLaAccion", @fechaDeLaAccion, LinqToDB.DataType.DateTime)
			};

			return dataConnection.ExecuteProc("[dbo].[SpInsertarBitacora]", parameters);
		}

		#endregion

		#region SpInsertarReservacion

		public static IEnumerable<SpInsertarReservacionResult> SpInsertarReservacion(this PvProyectoFinalDB dataConnection, int? @idPersona, int? @idHabitacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, char? @estado)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",  @idHabitacion,  LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",  @fechaEntrada,  LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",   @fechaSalida,   LinqToDB.DataType.Date),
				new DataParameter("@numeroAdultos", @numeroAdultos, LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",  @numeroNinhos,  LinqToDB.DataType.Int32),
				new DataParameter("@estado",        @estado,        LinqToDB.DataType.Char)
				{
					Size = 1
				}
			};

			return dataConnection.QueryProc<SpInsertarReservacionResult>("[dbo].[sp_InsertarReservacion]", parameters);
		}

		public partial class SpInsertarReservacionResult
		{
			public int? IdReservacion { get; set; }
		}

		#endregion

		#region SpLoginUsuario

		public static IEnumerable<SpLoginUsuarioResult> SpLoginUsuario(this PvProyectoFinalDB dataConnection, string @email, string @clave)
		{
			var parameters = new []
			{
				new DataParameter("@email", @email, LinqToDB.DataType.VarChar)
				{
					Size = 150
				},
				new DataParameter("@clave", @clave, LinqToDB.DataType.VarChar)
				{
					Size = 15
				}
			};

			return dataConnection.QueryProc<SpLoginUsuarioResult>("[dbo].[sp_LoginUsuario]", parameters);
		}

		public partial class SpLoginUsuarioResult
		{
			[Column("idPersona")     ] public int?   IdPersona      { get; set; }
			[Column("nombreCompleto")] public string NombreCompleto { get; set; }
			[Column("esEmpleado")    ] public bool?  EsEmpleado     { get; set; }
		}

		#endregion

		#region SpModificarEstadoHabitacion

		public static int SpModificarEstadoHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion, char? @estado)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32),
				new DataParameter("@estado",       @estado,       LinqToDB.DataType.Char)
				{
					Size = 1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_ModificarEstadoHabitacion]", parameters);
		}

		#endregion

		#region SpModificarHabitacion

		public static int SpModificarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion, string @numeroHabitacion, char? @estado)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion",     @idHabitacion,     LinqToDB.DataType.Int32),
				new DataParameter("@numeroHabitacion", @numeroHabitacion, LinqToDB.DataType.VarChar)
				{
					Size = 50
				},
				new DataParameter("@estado",           @estado,           LinqToDB.DataType.Char)
				{
					Size = 1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_ModificarHabitacion]", parameters);
		}

		#endregion

		#region SpModificarReservacion

		public static IEnumerable<SpModificarReservacionResult> SpModificarReservacion(this PvProyectoFinalDB dataConnection, int? @idReservacion, DateTime? @fechaEntrada, DateTime? @fechaSalida, int? @numeroAdultos, int? @numeroNinhos, int? @idHabitacion, decimal? @costoPorCadaAdulto, decimal? @costoPorCadaNinho, int? @totalDiasReservacion, decimal? @costoTotal, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion",        @idReservacion,        LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada",         @fechaEntrada,         LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",          @fechaSalida,          LinqToDB.DataType.Date),
				new DataParameter("@numeroAdultos",        @numeroAdultos,        LinqToDB.DataType.Int32),
				new DataParameter("@numeroNinhos",         @numeroNinhos,         LinqToDB.DataType.Int32),
				new DataParameter("@idHabitacion",         @idHabitacion,         LinqToDB.DataType.Int32),
				new DataParameter("@costoPorCadaAdulto",   @costoPorCadaAdulto,   LinqToDB.DataType.Decimal),
				new DataParameter("@costoPorCadaNinho",    @costoPorCadaNinho,    LinqToDB.DataType.Decimal),
				new DataParameter("@totalDiasReservacion", @totalDiasReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@costoTotal",           @costoTotal,           LinqToDB.DataType.Decimal),
				new DataParameter("@idPersona",            @idPersona,            LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpModificarReservacionResult>("[dbo].[sp_ModificarReservacion]", parameters);
		}

		public partial class SpModificarReservacionResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region SpObtenerHabitacionesPorHotel

		public static IEnumerable<SpObtenerHabitacionesPorHotelResult> SpObtenerHabitacionesPorHotel(this PvProyectoFinalDB dataConnection, int? @idHotel)
		{
			var parameters = new []
			{
				new DataParameter("@idHotel", @idHotel, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpObtenerHabitacionesPorHotelResult>("[dbo].[SpObtenerHabitacionesPorHotel]", parameters);
		}

		public partial class SpObtenerHabitacionesPorHotelResult
		{
			public int    IdHabitacion     { get; set; }
			public string NumeroHabitacion { get; set; }
			public char   Estado           { get; set; }
		}

		#endregion

		#region SpObtenerMisReservaciones

		public static IEnumerable<SpObtenerMisReservacionesResult> SpObtenerMisReservaciones(this PvProyectoFinalDB dataConnection, int? @IdUsuario)
		{
			var parameters = new []
			{
				new DataParameter("@IdUsuario", @IdUsuario, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpObtenerMisReservacionesResult>("[dbo].[SpObtenerMisReservaciones]", parameters);
		}

		public partial class SpObtenerMisReservacionesResult
		{
			[Column("idReservacion")] public int      IdReservacion { get; set; }
			[Column("fechaEntrada") ] public DateTime FechaEntrada  { get; set; }
			[Column("fechaSalida")  ] public DateTime FechaSalida   { get; set; }
			[Column("costoTotal")   ] public decimal  CostoTotal    { get; set; }
			[Column("estado")       ] public char     Estado        { get; set; }
			                          public string   NombreUsuario { get; set; }
			                          public string   NombreHotel   { get; set; }
			                          public string   EstadoVisual  { get; set; }
		}

		#endregion

		#region SpObtenerReservacionesConUsuario

		public static IEnumerable<SpObtenerReservacionesConUsuarioResult> SpObtenerReservacionesConUsuario(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpObtenerReservacionesConUsuarioResult>("[dbo].[SpObtenerReservacionesConUsuario]");
		}

		public partial class SpObtenerReservacionesConUsuarioResult
		{
			public int      Id                { get; set; }
			public string   NombreUsuario     { get; set; }
			public string   Correo            { get; set; }
			public DateTime FechaEntrada      { get; set; }
			public DateTime FechaSalida       { get; set; }
			public string   NombreHotel       { get; set; }
			public string   NumeroHabitacion  { get; set; }
			public decimal  CostoTotal        { get; set; }
			public string   EstadoReservacion { get; set; }
		}

		#endregion

		#region SpObtenerReservacionPorId

		public static IEnumerable<SpObtenerReservacionPorIdResult> SpObtenerReservacionPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpObtenerReservacionPorIdResult>("[dbo].[SpObtenerReservacionPorId]", parameters);
		}

		public partial class SpObtenerReservacionPorIdResult
		{
			[Column("idReservacion")       ] public int      IdReservacion        { get; set; }
			[Column("idPersona")           ] public int      IdPersona            { get; set; }
			[Column("idHabitacion")        ] public int      IdHabitacion         { get; set; }
			[Column("fechaEntrada")        ] public DateTime FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int      NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int      NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int      TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal  CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal  CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal  CostoTotal           { get; set; }
			[Column("estado")              ] public char     Estado               { get; set; }
			[Column("nombreCliente")       ] public string   NombreCliente        { get; set; }
			[Column("idHotel")             ] public int      IdHotel              { get; set; }
			                                 public string   NumeroHabitacion     { get; set; }
			                                 public string   NombreHotel          { get; set; }
		}

		#endregion

		#region SpReservacionesActivasPorHabitacion

		public static IEnumerable<SpReservacionesActivasPorHabitacionResult> SpReservacionesActivasPorHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			var ms = dataConnection.MappingSchema;

			return dataConnection.QueryProc(dataReader =>
				new SpReservacionesActivasPorHabitacionResult
				{
					Column1 = Converter.ChangeTypeTo<int>(dataReader.GetValue(0), ms),
				},
				"[dbo].[sp_ReservacionesActivasPorHabitacion]", parameters);
		}

		public partial class SpReservacionesActivasPorHabitacionResult
		{
			[Column("")] public int Column1 { get; set; }
		}

		#endregion

		#region SpReservacionesActivasPorHabitacion

		public static IEnumerable<Reservacion> SpReservacionesActivasPorHabitacion0(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<Reservacion>("[dbo].[SpReservacionesActivasPorHabitacion]", parameters);
		}

		#endregion

		#region SpValidarUsuario

		public static IEnumerable<SpValidarUsuarioResult> SpValidarUsuario(this PvProyectoFinalDB dataConnection, string @Email, string @Clave)
		{
			var parameters = new []
			{
				new DataParameter("@Email", @Email, LinqToDB.DataType.NVarChar)
				{
					Size = 150
				},
				new DataParameter("@Clave", @Clave, LinqToDB.DataType.NVarChar)
				{
					Size = 15
				}
			};

			return dataConnection.QueryProc<SpValidarUsuarioResult>("[dbo].[SP_ValidarUsuario]", parameters);
		}

		public partial class SpValidarUsuarioResult
		{
			public string Mensaje { get; set; }
		}

		#endregion

		#region SpVerClientesActivos

		public static IEnumerable<SpVerClientesActivosResult> SpVerClientesActivos(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpVerClientesActivosResult>("[dbo].[sp_VerClientesActivos]");
		}

		public partial class SpVerClientesActivosResult
		{
			[Column("idPersona")     ] public int    IdPersona      { get; set; }
			[Column("nombreCompleto")] public string NombreCompleto { get; set; }
		}

		#endregion

		#region SpVerHoteles

		public static IEnumerable<SpVerHotelesResult> SpVerHoteles(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpVerHotelesResult>("[dbo].[sp_VerHoteles]");
		}

		public partial class SpVerHotelesResult
		{
			[Column("idHotel")] public int    IdHotel { get; set; }
			[Column("nombre") ] public string Nombre  { get; set; }
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Bitacora Find(this ITable<Bitacora> table, int IdBitacora)
		{
			return table.FirstOrDefault(t =>
				t.IdBitacora == IdBitacora);
		}

		public static Habitacion Find(this ITable<Habitacion> table, int IdHabitacion)
		{
			return table.FirstOrDefault(t =>
				t.IdHabitacion == IdHabitacion);
		}

		public static Hotel Find(this ITable<Hotel> table, int IdHotel)
		{
			return table.FirstOrDefault(t =>
				t.IdHotel == IdHotel);
		}

		public static Persona Find(this ITable<Persona> table, int IdPersona)
		{
			return table.FirstOrDefault(t =>
				t.IdPersona == IdPersona);
		}

		public static Reservacion Find(this ITable<Reservacion> table, int IdReservacion)
		{
			return table.FirstOrDefault(t =>
				t.IdReservacion == IdReservacion);
		}
	}
}
