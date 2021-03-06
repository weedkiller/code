    string[] AttributeTags =
        txtAttributeTags.Text.Split
        (
            new string[] { "," },
            StringSplitOptions.RemoveEmptyEntries
        );
    var newTags = AttributeTags.Except
    (
        attribute.AttributeTag.Select(item => item.value),
        new CustomEqualityComparer<string>
        (
            (a, b) => 1, //your custom comparison here
            str => str.GetHashCode()
        )
    );
