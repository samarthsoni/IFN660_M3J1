  [TestMethod]

        public void Bool_test()

        {

            AssertBoolRule("true", true);
            AssertBoolRule("false", false);
        }

        [TestMethod]
        public void Bool_operator_test()
        {
            AssertOperatorRule("&&", "&&");
            AssertOperatorRule("||", "||");
            AssertOperatorRule("!", "!");
        }