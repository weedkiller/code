    public static Task<TResult> OnPropertyChanged<T, TResult>(this T target, Expression<Func<T, TResult>> propertyExpression) where T : INotifyPropertyChanged {
        var tcs = new TaskCompletionSource<TResult>();
        PropertyChangedEventHandler handler = null;
        var member = propertyExpression.GetMemberInfo();
        var propertyName = member.Name;
        if (member.MemberType != MemberTypes.Property)
            throw new ArgumentException(string.Format("{0} is an invalid property expression", propertyName));
        handler = (sender, args) => {
            if (string.Equals(args.PropertyName, propertyName, StringComparison.InvariantCultureIgnoreCase)) {
                target.PropertyChanged -= handler;
                var value = propertyExpression.Compile()(target);
                tcs.SetResult(value);
            }
        };
        target.PropertyChanged += handler;
        return tcs.Task;
    }
	/// <summary>
	/// Converts an expression into a <see cref="System.Reflection.MemberInfo"/>.
	/// </summary>
	/// <param name="expression">The expression to convert.</param>
	/// <returns>The member info.</returns>
	public static MemberInfo GetMemberInfo(this Expression expression) {
		var lambda = (LambdaExpression)expression;
		MemberExpression memberExpression;
		if (lambda.Body is UnaryExpression) {
			var unaryExpression = (UnaryExpression)lambda.Body;
			memberExpression = (MemberExpression)unaryExpression.Operand;
		} else
			memberExpression = (MemberExpression)lambda.Body;
		return memberExpression.Member;
	}
	
