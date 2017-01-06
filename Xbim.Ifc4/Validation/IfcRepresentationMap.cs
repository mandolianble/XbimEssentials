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
namespace Xbim.Ifc4.GeometryResource
{
	public partial class IfcRepresentationMap : IExpressValidatable
	{
		private static readonly ILog Log = LogManager.GetLogger("Xbim.Ifc4.GeometryResource.IfcRepresentationMap");

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(Where.IfcRepresentationMap clause) {
			var retVal = false;
			if (clause == Where.IfcRepresentationMap.ApplicableMappedRepr) {
				try {
					retVal = TYPEOF(MappedRepresentation).Contains("IFC4.IFCSHAPEMODEL");
				} catch (Exception ex) {
					Log.Error($"Exception thrown evaluating where-clause 'IfcRepresentationMap.ApplicableMappedRepr' for #{EntityLabel}.", ex);
				}
				return retVal;
			}
			throw new ArgumentException($"Invalid clause specifier: '{clause}'", nameof(clause));
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(Where.IfcRepresentationMap.ApplicableMappedRepr))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcRepresentationMap.ApplicableMappedRepr", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.Where
{
	public class IfcRepresentationMap
	{
		public static readonly IfcRepresentationMap ApplicableMappedRepr = new IfcRepresentationMap();
		protected IfcRepresentationMap() {}
	}
}