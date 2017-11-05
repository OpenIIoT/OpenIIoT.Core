/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀  ▀███  ▐██▀     ██       ▄█████ ██▄▄▄▄    ▄█████  █   ██████  ██▄▄▄▄    ▄█████
      █    ▄███▄▄▄       ██  ██   ▀███████▄   ██   █  ██▀▀▀█▄   ██  ▀  ██  ██    ██ ██▀▀▀█▄   ██  ▀
      █   ▀▀███▀▀▀        ████▀       ██  ▀  ▄██▄▄    ██   ██   ██     ██▌ ██    ██ ██   ██   ██
      █     ███    █▄     ████        ██    ▀▀██▀▀    ██   ██ ▀███████ ██  ██    ██ ██   ██ ▀███████
      █     ███    ███  ▄██ ▀██       ██      ██   █  ██   ██    ▄  ██ ██  ██    ██ ██   ██    ▄  ██
      █     ██████████ ███    ██▄    ▄██▀     ███████  █   █   ▄████▀  █    ██████   █   █   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Extension methods to assist with testing and assertions.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;

    /// <summary>
    ///     Extension methods to assist with testing and assertions.
    /// </summary>
    public static class Extensions
    {
        #region Public Methods

        /// <summary>
        ///     Returns a value incidating whether the specified <paramref name="instance"/> contains valid data according to the
        ///     data annotation attributes contained within the Type.
        /// </summary>
        /// <param name="instance">The instance to validate.</param>
        /// <returns>A value indicating whether the instance data is valid.</returns>
        public static bool DataAnnotationIsValid(this object instance)
        {
            ValidationContext context = new ValidationContext(instance, null, null);
            List<ValidationResult> results = new List<ValidationResult>();

            bool retVal = Validator.TryValidateObject(instance, context, results, true);

            return retVal;
        }

        /// <summary>
        ///     Returns the typed Content of the specified <see paramref="response"/>.
        /// </summary>
        /// <typeparam name="T">The desired Type of the Content.</typeparam>
        /// <param name="response">The response from which the Content is to be retrieved.</param>
        /// <returns>The typed Content, or default(T) if the Content can not be retrieved or cast.</returns>
        public static T GetContent<T>(this HttpResponseMessage response)
        {
            try
            {
                return (T)((ObjectContent<T>)response.Content).Value;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        ///     Injects the specified <paramref name="value"/> into the property matching the specified <paramref name="propertyName"/>.
        /// </summary>
        /// <param name="instance">The object instance into which the value is to be injected.</param>
        /// <param name="propertyName">The name of the property to be injected.</param>
        /// <param name="value">The value to be injected.</param>
        public static void Inject(this object instance, string propertyName, object value)
        {
            PropertyInfo property = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(p => p.Name == propertyName).FirstOrDefault();

            if (property == default(PropertyInfo))
            {
                throw new Exception($"Unable to find property '{propertyName}' in Type {instance.GetType().Name}.");
            }
            else
            {
                property.SetValue(instance, value);
            }
        }

        #endregion Public Methods
    }
}