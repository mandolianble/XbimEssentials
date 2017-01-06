using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using static Xbim.Ifc4.Functions;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.RepresentationResource
{
	public partial class IfcProjectedCRS : IExpressValidatable
	{
		private static readonly ILog Log = LogManager.GetLogger("Xbim.Ifc4.RepresentationResource.IfcProjectedCRS");

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(Where.IfcProjectedCRS clause) {
			var retVal = false;
			if (clause == Where.IfcProjectedCRS.IsLengthUnit) {
				try {
					retVal = !(EXISTS(MapUnit)) || (MapUnit.UnitType == IfcUnitEnum.LENGTHUNIT);
				} catch (Exception ex) {
					Log.Error($"Exception thrown evaluating where-clause 'IfcProjectedCRS.IsLengthUnit' for #{EntityLabel}.", ex);
				}
				return retVal;
			}
			throw new ArgumentException($"Invalid clause specifier: '{clause}'", nameof(clause));
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(Where.IfcProjectedCRS.IsLengthUnit))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcProjectedCRS.IsLengthUnit", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.Where
{
	public class IfcProjectedCRS
	{
		public static readonly IfcProjectedCRS IsLengthUnit = new IfcProjectedCRS();
		protected IfcProjectedCRS() {}
	}
}