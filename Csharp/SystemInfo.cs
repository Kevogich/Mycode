using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.IO;
///Summary
///C#调用DOS 命令
///Ref: https://jingyan.baidu.com/article/adc815133eb3a3f723bf73d8.html
///Summary
namespace SystemInfo1
{
  class GetSystemInfo
  {
	public  void SystemInfo()
	{
		InitializeComponent();
	}
	static void Main(string[] args)
	{
string Machinename = Enviroment.MachineName;
		string Result = p.StandardOutput.ReadToEnd();

		Console.WriteLine("{0}",MachineName);
		
	}
  }	
}
