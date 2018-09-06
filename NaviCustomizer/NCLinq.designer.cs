﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NaviCustomizer
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NaviCustDB")]
	public partial class NCLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertpiece(piece instance);
    partial void Updatepiece(piece instance);
    partial void Deletepiece(piece instance);
    partial void Insertpoint(point instance);
    partial void Updatepoint(point instance);
    partial void Deletepoint(point instance);
    #endregion
		
		public NCLinqDataContext() : 
				base(global::NaviCustomizer.Properties.Settings.Default.NaviCustDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NCLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NCLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<piece> pieces
		{
			get
			{
				return this.GetTable<piece>();
			}
		}
		
		public System.Data.Linq.Table<point> points
		{
			get
			{
				return this.GetTable<point>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.piece")]
	public partial class piece : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _id;
		
		private string _name;
		
		private string _color;
		
		private bool _textured;
		
		private bool _onGrid;
		
		private EntitySet<point> _points;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(string value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OncolorChanging(string value);
    partial void OncolorChanged();
    partial void OntexturedChanging(bool value);
    partial void OntexturedChanged();
    partial void OnonGridChanging(bool value);
    partial void OnonGridChanged();
    #endregion
		
		public piece()
		{
			this._points = new EntitySet<point>(new Action<point>(this.attach_points), new Action<point>(this.detach_points));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_color", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string color
		{
			get
			{
				return this._color;
			}
			set
			{
				if ((this._color != value))
				{
					this.OncolorChanging(value);
					this.SendPropertyChanging();
					this._color = value;
					this.SendPropertyChanged("color");
					this.OncolorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_textured", DbType="Bit NOT NULL")]
		public bool textured
		{
			get
			{
				return this._textured;
			}
			set
			{
				if ((this._textured != value))
				{
					this.OntexturedChanging(value);
					this.SendPropertyChanging();
					this._textured = value;
					this.SendPropertyChanged("textured");
					this.OntexturedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_onGrid", DbType="Bit NOT NULL")]
		public bool onGrid
		{
			get
			{
				return this._onGrid;
			}
			set
			{
				if ((this._onGrid != value))
				{
					this.OnonGridChanging(value);
					this.SendPropertyChanging();
					this._onGrid = value;
					this.SendPropertyChanged("onGrid");
					this.OnonGridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="piece_point", Storage="_points", ThisKey="id", OtherKey="id")]
		public EntitySet<point> points
		{
			get
			{
				return this._points;
			}
			set
			{
				this._points.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_points(point entity)
		{
			this.SendPropertyChanging();
			entity.piece = this;
		}
		
		private void detach_points(point entity)
		{
			this.SendPropertyChanging();
			entity.piece = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.points")]
	public partial class point : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _id;
		
		private int _x;
		
		private int _y;
		
		private EntityRef<piece> _piece;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(string value);
    partial void OnidChanged();
    partial void OnxChanging(int value);
    partial void OnxChanged();
    partial void OnyChanging(int value);
    partial void OnyChanged();
    #endregion
		
		public point()
		{
			this._piece = default(EntityRef<piece>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					if (this._piece.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_x", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int x
		{
			get
			{
				return this._x;
			}
			set
			{
				if ((this._x != value))
				{
					this.OnxChanging(value);
					this.SendPropertyChanging();
					this._x = value;
					this.SendPropertyChanged("x");
					this.OnxChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_y", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int y
		{
			get
			{
				return this._y;
			}
			set
			{
				if ((this._y != value))
				{
					this.OnyChanging(value);
					this.SendPropertyChanging();
					this._y = value;
					this.SendPropertyChanged("y");
					this.OnyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="piece_point", Storage="_piece", ThisKey="id", OtherKey="id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public piece piece
		{
			get
			{
				return this._piece.Entity;
			}
			set
			{
				piece previousValue = this._piece.Entity;
				if (((previousValue != value) 
							|| (this._piece.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._piece.Entity = null;
						previousValue.points.Remove(this);
					}
					this._piece.Entity = value;
					if ((value != null))
					{
						value.points.Add(this);
						this._id = value.id;
					}
					else
					{
						this._id = default(string);
					}
					this.SendPropertyChanged("piece");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
