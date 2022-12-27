using System;
using System.Collections.Generic;

namespace kycdetails.Models;

public partial class TbCustomerdetail
{
    public int TbId { get; set; }

    public string? TbCustomerId { get; set; }

    public string? TbCustomername { get; set; }

    public string? TbGender { get; set; }

    public string? TbMobile { get; set; }

    public string? TbDocumentType { get; set; }

    public int? TbIdNumber { get; set; }
}
