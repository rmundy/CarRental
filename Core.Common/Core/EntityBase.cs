// <copyright file="EntityBase.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the EntityBase.cs class.
// </summary>
namespace Core.Common.Core
{
    #region

    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// EntityBase class
    /// </summary>
    public abstract class EntityBase : IExtensibleDataObject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the structure that contains extra data.
        /// </summary>
        /// <returns>An <see cref="T:System.Runtime.Serialization.ExtensionDataObject" /> that contains data that is not recognized as belonging to the data contract.</returns>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}