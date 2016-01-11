﻿using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anathema
{
    interface ISettingsView : IView
    {
        // Methods invoked by the presenter (upstream)

    }

    interface ISettingsModel : IModel
    {
        // Events triggered by the model (upstream)

        // Functions invoked by presenter (downstream)
        void UpdateStateSettings(Boolean Free, Boolean Commit, Boolean Reserve);
        void UpdateTypeSettings(Boolean Private, Boolean Mapped, Boolean Image);
        void UpdateProtectionSettings(Boolean NoAccess, Boolean ReadOnly, Boolean ReadWrite, Boolean WriteCopy, Boolean Execute,
           Boolean ExecuteRead, Boolean ExecuteReadWrite, Boolean ExecuteWriteCopy, Boolean Guard, Boolean NoCache, Boolean WriteCombine);

        Boolean[] GetStateSettings();
        Boolean[] GetTypeSettings();
        Boolean[] GetProtectionSettings();

        Int32 GetFreezeInterval();
        Int32 GetRescanInterval();
        Int32 GetResultReadInterval();
        Int32 GetTableReadInterval();

        void UpdateIntervalSettings(Int32 FreezeInterval, Int32 RescanInterval, Int32 ResultReadInterval, Int32 TableReadInterval);
    }

    class SettingsPresenter : Presenter<ISettingsView, ISettingsModel>
    {
        protected new ISettingsView View { get; set; }
        protected new ISettingsModel Model { get; set; }

        public SettingsPresenter(ISettingsView View, ISettingsModel Model) : base(View, Model)
        {
            this.View = View;
            this.Model = Model;

            // Bind events triggered by the model
        }

        #region Method definitions called by the view (downstream)

        public void UpdateStateSettings(Boolean Free, Boolean Commit, Boolean Reserve)
        {
            Model.UpdateStateSettings(Free, Commit, Reserve);
        }

        public void UpdateTypeSettings(Boolean Private, Boolean Mapped, Boolean Image)
        {
            Model.UpdateTypeSettings(Private, Mapped, Image);
        }

        public void UpdateProtectionSettings(Boolean NoAccess, Boolean ReadOnly, Boolean ReadWrite, Boolean WriteCopy, Boolean Execute,
            Boolean ExecuteRead, Boolean ExecuteReadWrite, Boolean ExecuteWriteCopy, Boolean Guard, Boolean NoCache, Boolean WriteCombine)
        {
            Model.UpdateProtectionSettings(NoAccess, ReadOnly, ReadWrite, WriteCopy, Execute, ExecuteRead, ExecuteReadWrite, ExecuteWriteCopy, Guard, NoCache, WriteCombine);
        }

        public void UpdateIntervalSettings(Int32 FreezeInterval, Int32 RescanInterval, Int32 ResultReadInterval, Int32 TableReadInterval)
        {
            Model.UpdateIntervalSettings(FreezeInterval, RescanInterval, ResultReadInterval, TableReadInterval);
        }

        public Boolean[] GetStateSettings()
        {
            return Model.GetStateSettings();
        }

        public Boolean[] GetTypeSettings()
        {
            return Model.GetTypeSettings();
        }

        public Boolean[] GetProtectionSettings()
        {
            return Model.GetProtectionSettings();
        }

        public Int32 GetFreezeInterval()
        {
            return Model.GetFreezeInterval();
        }

        public Int32 GetRescanInterval()
        {
            return Model.GetRescanInterval();
        }

        public Int32 GetResultReadInterval()
        {
            return Model.GetResultReadInterval();
        }

        public Int32 GetTableReadInterval()
        {
            return Model.GetTableReadInterval();
        }

        #endregion

        #region Event definitions for events triggered by the model (upstream)

        #endregion
    }
}