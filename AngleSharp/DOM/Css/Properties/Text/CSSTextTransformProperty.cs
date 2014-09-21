﻿namespace AngleSharp.DOM.Css.Properties
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Information can be found on MDN:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform
    /// </summary>
    sealed class CSSTextTransformProperty : CSSProperty, ICssTextTransformProperty
    {
        #region Fields

        static readonly Dictionary<String, TextTransform> modes = new Dictionary<String, TextTransform>(StringComparer.OrdinalIgnoreCase);
        TextTransform _mode;

        #endregion

        #region ctor

        static CSSTextTransformProperty()
        {
            modes.Add(Keywords.None, TextTransform.None);
            modes.Add(Keywords.Capitalize, TextTransform.Capitalize);
            modes.Add(Keywords.Uppercase, TextTransform.Uppercase);
            modes.Add(Keywords.Lowercase, TextTransform.Lowercase);
            modes.Add(Keywords.FullWidth, TextTransform.FullWidth);
        }

        internal CSSTextTransformProperty()
            : base(PropertyNames.TextTransform, PropertyFlags.Inherited)
        {
            _mode = TextTransform.None;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected text transformation mode.
        /// </summary>
        public TextTransform Transform
        {
            get { return _mode; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines if the given value represents a valid state of this property.
        /// </summary>
        /// <param name="value">The state that should be used.</param>
        /// <returns>True if the state is valid, otherwise false.</returns>
        protected override Boolean IsValid(CSSValue value)
        {
            TextTransform mode;

            if (modes.TryGetValue(value, out mode))
                _mode = mode;
            else if (value != CSSValue.Inherit)
                return false;

            return true;
        }

        #endregion
    }
}
