// <copyright file="IAccountOwnedEntity.cs" company="Cylex">
//      All rights are reserved. Reproduction or transmission in whole or
//      in part, in any form or by any means, electronic, mechanical or
//      otherwise, is prohibited without the prior written consent of the 
//      copyright owner.
// </copyright>
// 
// <summary>
//      Definition of the IAccountOwnedEntity.cs class.
// </summary>
namespace Core.Common.Contracts
{
    #region

    using System;

    #endregion

    /// <summary>
    ///     IAccountOwnedEntity interface
    /// </summary>
    public interface IAccountOwnedEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the owner account identifier.
        /// </summary>
        /// <value>
        ///     The owner account identifier.
        /// </value>
        Guid OwnerAccountId { get; set; }

        #endregion
    }
}