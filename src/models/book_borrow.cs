//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhom8_QLTV.src.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book_borrow
    {
        public long id { get; set; }
        public Nullable<long> book_id { get; set; }
        public Nullable<long> borrow_id { get; set; }
        public Nullable<long> reader_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual book book { get; set; }
        public virtual borrow borrow { get; set; }
        public virtual reader reader { get; set; }
    }
}
