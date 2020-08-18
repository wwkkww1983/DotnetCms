﻿/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：文章管理界面显示的实体                                                    
*│　作    者：zhengshengyi                                           
*│　版    本：1.0                                                 
*│　创建时间：2020/8/18 12:40:47                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： DotnetCms.ViewModels.Article                                 
*│　类    名： ArticleListModel                                      
*└──────────────────────────────────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCms.ViewModels.Article
{
    public class ArticleListModel
    {
        /// <summary>
		/// 主键
		/// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public Int32 CategoryId { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public String ImageUrl { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public Int32 ViewCount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public Int32 Sort { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public String Author { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public String Source { get; set; }

        /// <summary>
        /// SEO标题
        /// </summary>
        public String SeoTitle { get; set; }

        /// <summary>
        /// SEO关键字
        /// </summary>
        public String SeoKeyword { get; set; }

        /// <summary>
        /// SEO描述
        /// </summary>
        public String SeoDescription { get; set; }

        /// <summary>
        /// 添加人ID
        /// </summary>
        public Int32 AddManagerId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 修改人ID
        /// </summary>
        public Int32? ModifyManagerId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public Boolean IsTop { get; set; }

        /// <summary>
        /// 是否轮播显示
        /// </summary>
        public Boolean IsSlide { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        public Boolean IsRed { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public Boolean IsPublish { get; set; }

    }
}
