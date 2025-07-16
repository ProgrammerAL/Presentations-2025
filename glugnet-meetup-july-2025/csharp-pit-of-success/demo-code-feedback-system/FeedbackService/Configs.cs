using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

namespace FeedbackService;

public class ServiceConfig
{
    [Required(AllowEmptyStrings = false), NotNull]
    public string? Environment { get; set; }

    [Required(AllowEmptyStrings = false), NotNull]
    public string? Version { get; set; }
}

[OptionsValidator]
public partial class ServiceConfigValidateOptions : IValidateOptions<ServiceConfig>
{
}

public class StorageConfig
{
    [Required(AllowEmptyStrings = false), NotNull]
    public string? Endpoint { get; set; }

    [Required(AllowEmptyStrings = false), NotNull]
    public string? TableName { get; set; }
}

[OptionsValidator]
public partial class StorageConfigValidateOptions : IValidateOptions<StorageConfig>
{
}