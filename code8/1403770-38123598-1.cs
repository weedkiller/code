        private static IEnumerable<Test> InitTestClass()
        {
            List<Test> lsttest = new List<Test>();
            Test test = new Test();
            test.Id = 100;
            test.Version = "0";
            test.TestOperation = new List<TestOperation>();
            test.TestOperation.Add(new TestOperation() { Id = 1, TestId = 100, SourceSubVariantId = 69, TargetSubVariantId = 70, variation = 0 });
            test.TestOperation.Add(new TestOperation() { Id = 1, TestId = 100, SourceSubVariantId = 70, TargetSubVariantId = 71, variation = 20 });
            test.TestOperation.Add(new TestOperation() { Id = 1, TestId = 100, SourceSubVariantId = 72, TargetSubVariantId = 73, variation = 90 });
            test.TestOperationDifference = new List<TestOperationDifference>();
            test.TestOperationDifference.Add(new TestOperationDifference() { Id = 1, TestId = 100, SourceSubVariantId = 66, TargetSubVariantId = 67, unmatch = 0 });
            test.TestOperationDifference.Add(new TestOperationDifference() { Id = 1, TestId = 100, SourceSubVariantId = 67, TargetSubVariantId = 68, unmatch = 2 });
            test.TestOperationDifference.Add(new TestOperationDifference() { Id = 1, TestId = 100, SourceSubVariantId = 74, TargetSubVariantId = 75, unmatch = 7 });
            test.TestOperationDifference.Add(new TestOperationDifference() { Id = 1, TestId = 100, SourceSubVariantId = 75, TargetSubVariantId = 76, unmatch = 0 });
            test.TestOperationDifference.Add(new TestOperationDifference() { Id = 1, TestId = 100, SourceSubVariantId = 77, TargetSubVariantId = 78, unmatch = 26 });
            var topSv = test.TestOperation.GetEnumerator();
            topSv.MoveNext();
            topSv.Current.SubVariants = new SubVariants() { Id = 69, Name = "Abc", VariantId = 12 };
            topSv.Current.SubVariants.Variants = new Variants() { Id = 12, Type = "Add", Name = "Variant1", CategoryId = 1 };
            topSv.MoveNext();
            topSv.Current.SubVariants = new SubVariants() { Id = 70, Name = "PQR", VariantId = 12 };
            topSv.Current.SubVariants.Variants = new Variants() { Id = 12, Type = "Add", Name = "Variant1", CategoryId = 1 };
            topSv.MoveNext();
            topSv.Current.SubVariants = new SubVariants() { Id = 72, Name = "Abc", VariantId = 13 };
            topSv.Current.SubVariants.Variants = new Variants() { Id = 13, Type = "Add", Name = "Variant2", CategoryId = 2 };
            var topSv1 = test.TestOperation.GetEnumerator();
            topSv1.MoveNext();
            topSv1.Current.SubVariants1 = new SubVariants() { Id = 70, Name = "PQR", VariantId = 12 };
            topSv1.Current.SubVariants1.Variants = new Variants() { Id = 12, Type = "Add", Name = "Variant1", CategoryId = 1 };
            topSv1.MoveNext();
            topSv1.Current.SubVariants1 = new SubVariants() { Id = 71, Name = "Xyz", VariantId = 12 };
            topSv1.Current.SubVariants1.Variants = new Variants() { Id = 12, Type = "Add", Name = "Variant1", CategoryId = 1 };
            topSv1.MoveNext();
            topSv1.Current.SubVariants1 = new SubVariants() { Id = 73, Name = "PQR", VariantId = 13 };
            topSv1.Current.SubVariants1.Variants = new Variants() { Id = 13, Type = "Add", Name = "Variant2", CategoryId = 2 };
            var topDiffSv = test.TestOperationDifference.GetEnumerator();
            topDiffSv.MoveNext();
            topDiffSv.Current.SubVariants = new SubVariants() { Id = 66, Name = "Abc", VariantId = 11 };
            topDiffSv.Current.SubVariants.Variants = new Variants() { Id = 11, Type = "Diff", Name = "Variant1", CategoryId = 1 };
            topDiffSv.MoveNext();
            topDiffSv.Current.SubVariants = new SubVariants() { Id = 67, Name = "PQR", VariantId = 11 };
            topDiffSv.Current.SubVariants.Variants = new Variants() { Id = 11, Type = "Diff", Name = "Variant1", CategoryId = 1 };
            topDiffSv.MoveNext();
            topDiffSv.Current.SubVariants = new SubVariants() { Id = 74, Name = "Abc", VariantId = 14 };
            topDiffSv.Current.SubVariants.Variants = new Variants() { Id = 14, Type = "Diff", Name = "Variant2", CategoryId = 2 };
            topDiffSv.MoveNext();
            topDiffSv.Current.SubVariants = new SubVariants() { Id = 75, Name = "PQR", VariantId = 14 };
            topDiffSv.Current.SubVariants.Variants = new Variants() { Id = 14, Type = "Diff", Name = "Variant2", CategoryId = 2 };
            topDiffSv.MoveNext();
            topDiffSv.Current.SubVariants = new SubVariants() { Id = 77, Name = "ABC", VariantId = 13 };
            topDiffSv.Current.SubVariants.Variants = new Variants() { Id = 13, Type = "Add", Name = "Variant2", CategoryId = 2 };
            var topDiffSv1 = test.TestOperationDifference.GetEnumerator();
            topDiffSv1.MoveNext();
            topDiffSv1.Current.SubVariants1 = new SubVariants() { Id = 67, Name = "PQR", VariantId = 11 };
            topDiffSv1.Current.SubVariants1.Variants = new Variants() { Id = 11, Type = "Diff", Name = "Variant1", CategoryId = 1 };
            topDiffSv1.MoveNext();
            topDiffSv1.Current.SubVariants1 = new SubVariants() { Id = 68, Name = "Xyz", VariantId = 11 };
            topDiffSv1.Current.SubVariants1.Variants = new Variants() { Id = 11, Type = "Diff", Name = "Variant1", CategoryId = 1 };
            topDiffSv1.MoveNext();
            topDiffSv1.Current.SubVariants1 = new SubVariants() { Id = 75, Name = "PQR", VariantId = 14 };
            topDiffSv1.Current.SubVariants1.Variants = new Variants() { Id = 14, Type = "Diff", Name = "Variant2", CategoryId = 2 };
            topDiffSv1.MoveNext();
            topDiffSv1.Current.SubVariants1 = new SubVariants() { Id = 76, Name = "Xyz", VariantId = 14 };
            topDiffSv1.Current.SubVariants1.Variants = new Variants() { Id = 14, Type = "Diff", Name = "Variant2", CategoryId = 2 };
            topDiffSv1.MoveNext();
            topDiffSv1.Current.SubVariants1 = new SubVariants() { Id = 78, Name = "PQR", VariantId = 15 };
            topDiffSv1.Current.SubVariants1.Variants = new Variants() { Id = 15, Type = "Add", Name = "Variant3", CategoryId = 3 };
            lsttest.Add(test);
            return lsttest;
        }
    }
