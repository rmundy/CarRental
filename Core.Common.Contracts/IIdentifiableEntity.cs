// <copyright file="IIdentifiableEntity.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the IIdentifiableEntity.cs class.
// </summary>
namespace Core.Common.Contracts
{
    #region

    using System;

    #endregion

    /// <summary>
    /// IIdentifiableEntity interface
    /// </summary>
    public interface IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        Guid EntityId { get; set; }

        #endregion
    }
}