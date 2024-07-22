// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

namespace MixedReality.Toolkit.Accessibility
{
    /// <summary>
    /// Enum that specifies how caption backgrounds are to be displayed. 
    /// </summary>
    public enum TextBackplateBehavior
    {
        /// <summary>
        /// The text will be displayed without a backplate.
        /// </summary>
        None = 0,

        /// <summary>
        /// The text will be displayed with a backplate in AR scenarios
        /// and without in VR scenarios.
        /// </summary>
        Automatic = 1,

        /// <summary>
        /// The text will be displayed with a backplate.
        /// </summary>
        Constant = 2
    }

}
