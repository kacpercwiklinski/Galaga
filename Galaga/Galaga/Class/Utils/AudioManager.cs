﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Galaga.Class.Utils
{
    public class AudioManager
    {

        public SoundEffect shoot;
        public SoundEffect boom;
     

        public AudioManager(ContentManager theContent)
        {
            loadAudios(theContent);
        }

        private void loadAudios(ContentManager theContent)
        {
            shoot = theContent.Load<SoundEffect>("audio/pewpew");
            boom = theContent.Load<SoundEffect>("audio/explosion");
         
        }

    }
}
