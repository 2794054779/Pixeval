﻿// Pixeval - A Strong, Fast and Flexible Pixiv Client
// Copyright (C) 2019 Dylech30th
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using Pixeval.Objects;

namespace Pixeval.Core
{
    public class IllustrationQualification
    {
        public IllustrationQualification(ConditionType type, string condition)
        {
            Type = type;
            Condition = condition;
        }

        public ConditionType Type { get; set; }

        public string Condition { get; set; }

        public static IllustrationQualification Parse(string input)
        {
            return new IllustrationQualification(input switch
            {
                _ when input.IsNumber()       => ConditionType.Id,
                _ when input.StartsWith("!")  => ConditionType.ExcludeTag,
                _ when !input.IsNullOrEmpty() => ConditionType.Tag,
                _                             => ConditionType.None
            }, input);
        }
    }

    public enum ConditionType
    {
        Id,
        Tag,
        ExcludeTag,
        None
    }
}