using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.Abbreviate;
using Asmodat.Kraken;

namespace Asmodat_Web_Exchange
{
    public static class UpdateDropDownListSEx
    {
        public static bool EqulsText(this ListItem primary, ListItem secondary)
        {
            if (primary == null || secondary == null)
                return false;

            if (primary.Text == secondary.Text)
                return true;

            return false;
        }
        public static bool EqulsValue(this ListItem primary, ListItem secondary)
        {
            if (primary == null || secondary == null)
                return false;

            if (primary.Value == secondary.Value)
                return true;

            return false;
        }

        public static int SelectText(this UpdateDropDownList uddl, string text)
        {
            if (uddl == null || uddl.Items == null)
                return -1;

            for (int i = 0; i < uddl.Items.Count; i++)
            {
                ListItem primary = uddl.Items[i];
                if (primary != null && primary.Text == text)
                {
                    uddl.SelectedIndex = i;
                    return i;
                }
            }

            return -1;
        }
        public static int SelectValue(this UpdateDropDownList uddl, string value)
        {
            if (uddl == null || uddl.Items == null)
                return -1;

            for (int i = 0; i < uddl.Items.Count; i++)
            {
                ListItem primary = uddl.Items[i];
                if (primary != null && primary.Value == value)
                {
                    uddl.SelectedIndex = i;
                    return i;
                }
            }

            return -1;
        }

        public static bool ContainsText(this UpdateDropDownList uddl, string text)
        {
            if (uddl == null || uddl.Items == null)
                return false;

            for (int i = 0; i < uddl.Items.Count; i++)
            {
                ListItem primary = uddl.Items[i];
                if (primary != null && primary.Text == text)
                    return true;
            }

            return false;
        }
        public static bool ContainsValue(this UpdateDropDownList uddl, string value)
        {
            if (uddl == null || uddl.Items == null)
                return false;

            for (int i = 0; i < uddl.Items.Count; i++)
            {
                ListItem primary = uddl.Items[i];
                if (primary != null && primary.Value == value)
                    return true;
            }

            return false;
        }

    }
}