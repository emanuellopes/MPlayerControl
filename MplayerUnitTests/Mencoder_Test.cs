﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace MplayerUnitTests
{

    [TestFixture()]
    public class Mencoder_Test
    {


        [Test()]
        public void Convert2WebMTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            a.Convert2WebM(GlobalVariables.Video8Path, GlobalVariables.OutputVideoWebM);
        }

        [Test()]
        public async void Convert2WebMAsyncTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            await a.Convert2WebMAsync(GlobalVariables.Video8Path, GlobalVariables.OutputVideoWebM);
        }


        [Test()]
        public void Convert2X264Test()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            a.Convert2X264(GlobalVariables.Video8Path, GlobalVariables.OutputVideoX264);
        }

        [Test()]
        public async void Convert2X264AsyncTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            await a.Convert2X264Async(GlobalVariables.Video8Path, GlobalVariables.OutputVideoX264);
        }

        [Test()]
        public void Convert2DvdMpegPalTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            a.Convert2DvdMpeg(LibMPlayerCommon.Mencoder.RegionType.PAL, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegPal);
        }

        [Test()]
        public async void Convert2DvdMpegPalAsyncTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            await a.Convert2DvdMpegAsync(LibMPlayerCommon.Mencoder.RegionType.PAL, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegPal);
        }

        [Test()]
        public void Convert2DvdMpegNtscTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            a.Convert2DvdMpeg(LibMPlayerCommon.Mencoder.RegionType.NTSC, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegNtsc);

            a.ConversionComplete += a_ConversionComplete;
        }

        [Test()]
        public async void Convert2DvdMpegNtscAsyncTest()
        {
            LibMPlayerCommon.Mencoder a = new LibMPlayerCommon.Mencoder();
            await a.Convert2DvdMpegAsync(LibMPlayerCommon.Mencoder.RegionType.NTSC, GlobalVariables.Video8Path, GlobalVariables.OutputVideoDvdMpegNtsc);

        }

        private void a_ConversionComplete(object sender, LibMPlayerCommon.MplayerEvent e)
        {
            LibMPlayerCommon.Discover a = new LibMPlayerCommon.Discover(GlobalVariables.OutputVideoDvdMpegNtsc, GlobalVariables.MplayerPath);
            NUnit.Framework.Assert.AreEqual(192, a.AudioBitrate);
            NUnit.Framework.Assert.AreEqual(720, a.Width);
            NUnit.Framework.Assert.AreEqual(480, a.Height);
            NUnit.Framework.Assert.AreEqual(48000, a.AudioSampleRate);

        }
    }
}
