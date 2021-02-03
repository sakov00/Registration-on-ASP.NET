using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WorkRegistration.Styles
{
    public static class MyValidationHelper
    {
        public static MvcHtmlString MyValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            string str= expression.Body.ToString().Substring(expression.Body.ToString().IndexOf('.') + 1);
                str = str.Substring(str.IndexOf('.') + 1);
            int count = str.Length;
            for (int i = 1; i < count; i++)
            {
                if (str[i] == str.ToUpper()[i])
                {
                    string str2 = str.Substring(i);
                    string str1 = str.Substring(0, i);
                    str = str1 +" "+ str2;
                    break;
                }
            }
            //<a class="lake" alt="mem"><img src="@Url.Content("~/Images/image.png")" style="width:15px; height:15px;"></a>
            TagBuilder bossdiv = new TagBuilder("div");
            bossdiv.AddCssClass("field-error-box");

            TagBuilder topDivBuilder = new TagBuilder("div");
            topDivBuilder.AddCssClass("top");
            topDivBuilder.InnerHtml = "<img src ='/Images/image.png' style ='width:15px;height:15px;'>" + helper.ValidationMessageFor(expression, "Error").ToString();
            topDivBuilder.Attributes.Add("style", "border-bottom:solid 1px gray;");

            TagBuilder bottomDivBuilder = new TagBuilder("div");
            bottomDivBuilder.AddCssClass("bottom");
            bottomDivBuilder.InnerHtml = helper.ValidationMessageFor(expression,str + " is required").ToString();
            bossdiv.InnerHtml += topDivBuilder.ToString(TagRenderMode.Normal);
            bossdiv.InnerHtml += bottomDivBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(bossdiv.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString CheckboxValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string str)
        {
            //<a class="lake" alt="mem"><img src="@Url.Content("~/Images/image.png")" style="width:15px; height:15px;"></a>
            TagBuilder bossdiv = new TagBuilder("div");
            bossdiv.AddCssClass("field-error-box");

            TagBuilder topDivBuilder = new TagBuilder("div");
            topDivBuilder.AddCssClass("top");
            topDivBuilder.InnerHtml = "<img src ='/Images/image.png' style ='width:15px;height:15px;'>" + helper.ValidationMessageFor(expression,"Error").ToString();
            topDivBuilder.Attributes.Add("style", "border-bottom:solid 1px gray;");

            TagBuilder midDivBuilder = new TagBuilder("div");
            midDivBuilder.AddCssClass("bottom");
            midDivBuilder.InnerHtml = helper.ValidationMessageFor(expression, str).ToString();
            bossdiv.InnerHtml += topDivBuilder.ToString(TagRenderMode.Normal);
            bossdiv.InnerHtml += midDivBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(bossdiv.ToString(TagRenderMode.Normal));
        }
    }
}