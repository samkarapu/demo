using System;
using System.Diagnostics;
using System.Management;

namespace BasicCompany.Foundation.Common.UITests.Services
{
  public class ProcessService
  {
    public void KillProcessAndChildren(string p_name)
    {
      var searcher = new ManagementObjectSearcher
        ("Select * From Win32_Process Where Name = '" + p_name + "'");

      var moc = searcher.Get();
      foreach (var o in moc)
      {
        var mo = (ManagementObject)o;

        try
        {
          KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
        }
        catch (ArgumentException)
        {
          break;
        }
      }

    }

    private void KillProcessAndChildren(int pid)
    {
      var searcher = new ManagementObjectSearcher
        ("Select * From Win32_Process Where ParentProcessID=" + pid);
      var moc = searcher.Get();
      foreach (var o in moc)
      {
        var mo = (ManagementObject)o;

        try
        {
          KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
        }
        catch
        {
          break;
        }
      }

      try
      {
        var proc = Process.GetProcessById(pid);
        proc.Kill();
      }
      catch (ArgumentException)
      {
        // Process already exited.
      }
    }
  }
}
