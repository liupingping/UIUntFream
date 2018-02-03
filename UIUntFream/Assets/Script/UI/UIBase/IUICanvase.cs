using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 public interface IUICanvase
 {

     void setup(object ob);

     void initView();

     void setActive(bool isActive);

     void destory();
 }