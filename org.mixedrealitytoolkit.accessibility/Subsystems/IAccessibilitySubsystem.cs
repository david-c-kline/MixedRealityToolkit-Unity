// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using System;
using System.Collections.Generic;
using UnityEngine;

namespace MixedReality.Toolkit.Accessibility
{
    /// <summary>
    /// Cross-platform, portable set of specifications for which an Accessibility Subsystem is capable. Both the Accessibility
    /// subsystem and the associated provider must implement this interface, preferably with a direct mapping or wrapping between
    /// the provider surface and the subsystem surface.
    /// </summary>
    public partial interface IAccessibilitySubsystem
    {
        #region Accessible object management

        /// <summary>
        /// Attempts to retrieve the collection of <see cref="AccessibleObjectClassification"/> instances for the objects
        /// that have been registered.
        /// </summary>
        /// <param name="classifications">List to receive the collection of registered <see cref="AccessibleObjectClassification"/> instances.</param>
        /// <returns><see langword="true"/> if classifications have been successfully retrieved, or <see langword="false"/>.</returns>
        /// <remarks>
        /// The passed in list will be cleared then filled with all <see cref="AccessibleObjectClassification"/> instances that match
        /// a previously registered object. Classifications are not removed after all matching objects have been
        /// unregistered.
        /// </remarks>
        bool TryGetAccessibleObjectClassifications(List<AccessibleObjectClassification> classifications);

        /// <summary>
        /// Attempts to register the specified <see cref="GameObject"/> using the associated <see cref="AccessibleObjectClassification"/>.
        /// </summary>
        /// <param name="accessibleObject">The <see cref="GameObject"/> to be registered.</param>
        /// <param name="classification">The classification (people, places, things, etc.) for the <see cref="GameObject"/>.</param>
        /// <returns><see langword="true"/> if successfully registered or <see langword="false"/>.</returns>
        /// <remarks>
        /// The registration process requires that a <see cref="GameObject"/> belongs to exactly one classification.
        /// </remarks>
        bool TryRegisterAccessibleObject(GameObject accessibleObject, AccessibleObjectClassification classification);

        /// <summary>
        /// Attempts to unregister the specified <see cref="GameObject"/> using the associated <see cref="AccessibleObjectClassification"/>
        /// </summary>
        /// <param name="accessibleObject">The <see cref="GameObject"/> to be unregistered.</param>
        /// <param name="classification">The classification (people, places, things, etc.) for the <see cref="GameObject"/>.</param>
        /// <remarks>
        /// The registration process requires that a <see cref="GameObject"/> belongs to exactly one classification.
        /// </remarks>
        bool TryUnregisterAccessibleObject(GameObject accessibleObject, AccessibleObjectClassification classification);

        #endregion Accessible object management

        #region Text accessibility

        #region Text backplate behavior

        /// <summary>
        /// How should text backplates be displayed?
        /// </summary>
        /// <remarks>
        /// This property applies to TextMeshPro objects with an attached <see cref="TextAccessibility"/> script.
        /// </remarks>
        TextBackplateBehavior TextBackplateBehavior { get; set; }

        /// <summary>
        /// Indicates that the value of <see cref="TextBackplateBehavior"/> has been changed.
        /// </summary>
        event Action<TextBackplateBehavior> TextBackplateBehaviorChanged;

        /// <summary>
        /// Provides a the behavior to be elicited by text backplates.
        /// </summary>
        /// <param name="behavior">The <see cref="TextBackplateBehavior"/> of the text backplate.</param>
        /// <remarks>
        /// This method requires the material to use the Text Mesh Pro shader which is
        /// provided in the Microsoft Mixed Reality Toolkit Graphics Tools package.
        /// </remarks>
        void ApplyTextBackplateBehavior(TextBackplateBehavior behavior);

        #endregion Text backplate behavior
        
        #region Text color inversion

        /// <summary>
        /// Should text color inversion be enabled?
        /// </summary>
        /// <remarks>
        /// This property applies to TextMeshPro objects with an attached <see cref="TextAccessibility"/> script.
        /// </remarks>
        bool InvertTextColor { get; set; }

        /// <summary>
        /// Indicates that the value of <see cref="InvertTextColor"/> has been changed.
        /// </summary>
        event Action<bool> InvertTextColorChanged;

        /// <summary>
        /// Enables or disables text color inversion.
        /// </summary>
        /// <param name="material">The material to which to apply text color inversion.</param>
        /// <param name="enable"><see langword="true"/> to enable inversion, or <see langword="false"/>.</param>
        /// <remarks>
        /// This method requires the material to use the Text Mesh Pro shader which is
        /// provided in the Microsoft Mixed Reality Toolkit Graphics Tools package.
        /// </remarks>
        void ApplyTextColorInversion(Material material, bool enable);

        #endregion Text color inversion

        #endregion Text accessibility
    }
}
