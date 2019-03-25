using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X12N.Framework;
using X12N.Framework.BaseCL;
using X12N.Framework.Loop1000A;
using X12N.Framework.Loop1000B;
using X12N.Framework.Loop2000C;
using X12N.Framework.Loop2010AA;
using X12N.Framework.Loop2010BA;
using X12N.Framework.Loop2010BB;
using X12N.Framework.Loop2010CA;
using X12N.Framework.Loop2300;
using X12N.Framework.Loop2310B;
using X12N.Framework.Loop2310C;
using X12N.Framework.Loop2400;
using X12N.HelperCLass;
using X12N.Repository;

namespace X12N.ProtocolBL
{
    class Base837BL
    {
        string filePath, procName;

        public Base837BL(string filePath, string procName)
        {
            this.filePath = filePath;
            this.procName = procName;
        }

        public ISA CreateHeader()
        {
            ISA isa = new ISA();

            GS gs = new GS();
            isa.SetSuccessor(gs);

            ST st = new ST();
            gs.SetSuccessor(st);

            BHT bht = new BHT();
            st.SetSuccessor(bht);

            Loop1000A loop1000A = new Loop1000A();
            bht.SetSuccessor(loop1000A);

            Loop1000B loop1000B = new Loop1000B();
            loop1000A.SetSuccessor(loop1000B);

            return isa;
        }

        public Loop2010AA CreateTransaction(int rowCnt = 0)
        {
            Loop2010AA loop2010AA;
            Loop2010BA loop2010BA;
            Loop2010BB loop2010BB;
            Loop2000C loop2000C;
            Loop2010CA loop2010CA;
            Loop2300 loop2300;
            Loop2310B loop2310B;
            Loop2310C loop2310C;
            Loop2400 loop2400 = null;

            loop2010AA = new Loop2010AA(rowCnt);
            //loop1000B.SetSuccessor(loop2010AA);

            loop2010BA = new Loop2010BA(rowCnt);
            loop2010AA.SetSuccessor(loop2010BA);

            loop2010BB = new Loop2010BB(rowCnt);
            loop2010BA.SetSuccessor(loop2010BB);

            loop2000C = new Loop2000C(rowCnt);
            loop2010BB.SetSuccessor(loop2000C);

            loop2010CA = new Loop2010CA(rowCnt);
            loop2000C.SetSuccessor(loop2010CA);

            loop2300 = new Loop2300(rowCnt);
            loop2010CA.SetSuccessor(loop2300);

            loop2310B = new Loop2310B(rowCnt);
            loop2300.SetSuccessor(loop2310B);

            loop2310C = new Loop2310C(rowCnt);
            loop2310B.SetSuccessor(loop2310C);

            loop2400 = new Loop2400(rowCnt);
            loop2310C.SetSuccessor(loop2400);

            return loop2010AA;
        }

        public SE CreateTrailor()
        {
            SE se = new SE();

            GE ge = new GE();
            se.SetSuccessor(ge);

            IEA iea = new IEA();
            ge.SetSuccessor(iea);

            return se;
        }

        public Base procecssMessage()
        {
            DataSet ds;
            DataTable dt = null;
            ISA isa = null;
            Loop2010AA loop2010AA = null;
            SE se = null;
            Boolean loopFlag = true;
            String fileName = string.Empty;

            int count = 0;
            ClaimRepository claimRepository = new ClaimRepository();
            try
            {
                do
                {

                    ds = claimRepository.GetClaimDetails("GetPregMedClaimData");

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0].Copy();

                        if (isa == null)
                        {
                            isa = this.CreateHeader();
                            isa.SetValues(dt);
                            fileName = FileManager.WriteFile(fileName, isa.ToString());
                        }

                        loop2010AA = this.CreateTransaction();
                        loop2010AA.SetValues(dt);
                        FileManager.WriteFile(fileName, loop2010AA.ToString());
                        this.UpdateStatus(true, dt.Rows[0]["ID"].ToString());
                        count++;
                    }
                    else
                        break;
                } while (loopFlag);

                se = this.CreateTrailor();
                se.SetValues(dt, (count * 35 + 6));
                FileManager.WriteFile(fileName, se.ToString());
            }catch(Exception ex)
            {

            }

            Console.WriteLine("Claims processed count {0} and path of claim file {1}", count.ToString(), ConfigurationManager.AppSettings["Filepath"].ToString());
            return isa;
        }

        public void UpdateStatus(bool status, string id)
        {
            ClaimRepository claimRepository = new ClaimRepository();
            claimRepository.UpdateClaimStatus(id, status);
        }

        //public void UpdateFileStatus(bool status, int noOfCliams, )
        //{
        //    ClaimRepository claimRepository = new ClaimRepository();
        //    claimRepository.UpdateClaimStatus(id, status);
        //}
    
    }
}
