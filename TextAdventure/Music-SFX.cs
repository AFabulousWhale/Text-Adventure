using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace TextAdventure
{
    class Music_SFX
    {
        public static void MenuMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\menu_music.wav");               
            simpleSound.PlayLooping();
        }

        public static void StartMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\start_music.wav");
            simpleSound.PlayLooping();

        }

        public static void GothesmeMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\Gothesme_music.wav");
            simpleSound.PlayLooping();
        }

        public static void BattleMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music/boss_battle.wav");
            simpleSound.PlayLooping();
        }

        public static void RezelleMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\reezelle_music.wav");
            simpleSound.PlayLooping();
        }

        public static void World1Music()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\world1_music.wav");
            simpleSound.PlayLooping();
        }

        public static void DogMainMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\dog_main.wav");
            simpleSound.PlayLooping();
        }

        public static void DogBattleMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\dog_fight.wav");
            simpleSound.PlayLooping();
        }

        public static void BarMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\bar_music.wav");
            simpleSound.PlayLooping();
        }

        public static void HorseMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\shop2_music.wav");
            simpleSound.PlayLooping();
        }

        public static void CastleMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\castle_music.wav");
            simpleSound.PlayLooping();
        }

        public static void QuizMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\quiz_music.wav");
            simpleSound.PlayLooping();
        }

        public static void DeathMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\death_music.wav");
            simpleSound.PlayLooping();
        }

        public static void BossMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\final_boss_battle.wav");
            simpleSound.PlayLooping();
        }

        public static void CreditsMusic()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"sounds-music\credits.wav");
            simpleSound.PlayLooping();
        }
    }
}
