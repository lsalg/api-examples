       [Route("api/PROP/PROP_ID/{id}/{PROP_DATE}/{PROP_DATE2}")]
        public IEnumerable<TempObj> Get(string id, string Prop_DATE, string PROP_DATE2)
        {
            //use helper class with function to return tempobj
            return svc.GetProps(LocID, Prop_DATE, PROP_DATE2);
        }


        [Route("api/PROP/Load")]
        public IEnumerable<Obj> Get()
        {
            //use helper class with function to return all types
            return svc.GetProps();
        }