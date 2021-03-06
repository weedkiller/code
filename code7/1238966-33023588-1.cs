      var _MockEntity = new Mock<db>();
      var _MockDrivers = new Mock<Drivers>();
      var _MockDriver = new Mock<Driver>();
      _MockEntity.Setup(x => x.Drivers()).Returns(() => _MockDrivers.Object);
      _MockDrivers.Setup(x => x.Find(123)).Returns(() => _MockDriver.Object); 
      _MockDriver.SetupProperty(x => x.EffectiveDate);
      _MockDriver.SetupProperty(x => x.LastModifiedBy);  
      _MockDriver.SetupProperty(x => x.LastModifiedDate); 
      myClass.UpdateEffectiveDate(_MockEntity.Object, 123, samedatehere,"test");
      var _Driver = _MockDriver.Object;
      var _Expected =  samedatehere;
      var _Actual =_Driver.EffectiveDate;
      Assert.Equal(_Expected, _Actual);  
