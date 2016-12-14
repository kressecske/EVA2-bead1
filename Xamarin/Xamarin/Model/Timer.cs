﻿using System;

namespace Labyrinth.Model
{
    /// <summary>
    /// Időzítő típusa.
    /// </summary>
    public class Timer : IDisposable
    {
        private System.Threading.Timer _timer; // használjuk a beépített időzítőt
        private TimeSpan _interval;
        private Boolean _autoReset;
        private Boolean _enabled;

        /// <summary>
        /// Ismételt eseményjelzés lekérdezése, vagy beállítása.
        /// </summary>
        public Boolean AutoReset { 
            get { return _autoReset; } 
            set { _autoReset = value; } 
        }

        /// <summary>
        /// Bekapcsolt állapot lekérdezése, vagy beállítása.
        /// </summary>
        public Boolean Enabled { 
            get { return _enabled; } 
            set { if (value) Start(); else Stop(); } 
        }

        /// <summary>
        /// Időintervallum lekérdezése, vagy beállítása (ezred másodpercben).
        /// </summary>
        public Double Interval { 
            get { return _interval.TotalMilliseconds; } 
            set { _interval = TimeSpan.FromMilliseconds(value); if (_enabled) Start(); } 
        }

        /// <summary>
        /// Idő eltelésének eseménye.
        /// </summary>
        public ElapsedEventHandler Elapsed;

        /// <summary>
        /// Időzítő példányosítása.
        /// </summary>
        public Timer()
        {
            _interval = TimeSpan.FromMilliseconds(100);
            _enabled = false;
            _autoReset = true;
        }

        /// <summary>
        /// Időzítő példányosítása.
        /// </summary>
        /// <param name="interval">Az időintervallum (ezred másodpercben).</param>
        public Timer(Double interval)
        {
            _interval = TimeSpan.FromMilliseconds(interval);
            _enabled = false;
            _autoReset = true;
        }

        /// <summary>
        /// Időzítő megsemmisítése.
        /// </summary>
        ~Timer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Időzítő indítása.
        /// </summary>
        public void Start()
        {
            if (_timer != null)
                _timer.Dispose();

            if (_autoReset)
                _timer = new System.Threading.Timer(Timeout, null, 0, Convert.ToInt32(_interval.TotalMilliseconds));
            else
                _timer = new System.Threading.Timer(Timeout, null, Convert.ToInt32(_interval.TotalMilliseconds), System.Threading.Timeout.Infinite);
            _enabled = true;
        }

        /// <summary>
        /// Időzítő leállítása.
        /// </summary>
        public void Stop()
        {
            if (_timer == null)
                return;

            _timer.Dispose();
            _timer = null;
            _enabled = false;
        }

        /// <summary>
        /// Erőforrások felszabadítása.
        /// </summary>
        public void Close()
        {
            Dispose(true);
        }

        /// <summary>
        /// Erőforrások felszabadítása.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Idő lejártának eseménykezelője.
        /// </summary>
        private void Timeout(Object state)
        {
            if (Elapsed != null)
                Elapsed(this, new ElapsedEventArgs());

            if (!_autoReset)
                _enabled = false;
        }

        /// <summary>
        /// Megsemmisítés végrehajtása.
        /// </summary>
        /// <param name="disposing">Felügyelt erőforrások megsemmisítése.</param>
        private void Dispose(Boolean disposing)
        {
            if (_timer != null)
                _timer.Dispose();

            if (disposing)
            {                
                _timer = null;
            }
        }
    }
}
