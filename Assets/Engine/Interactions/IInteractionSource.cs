﻿namespace SS3D.Engine.Interactions
{
    public interface IInteractionSource
    {
        IInteractionSource Parent { get; set; }
        /// <summary>
        /// Generates an ordered array of all interactions (not checked against CanExecute)
        /// </summary>
        /// <param name="targets">The interaction targets to check</param>
        /// <returns>The interactions, ordered by priority</returns>
        IInteraction[] GenerateInteractions(IInteractionTarget[] targets);
        /// <summary>
        /// Checks if this source can interact with a certain target
        /// </summary>
        /// <param name="target">The interaction target to check against</param>
        /// <returns>If the interaction target is supported</returns>
        bool CanInteractWithTarget(IInteractionTarget target);
        /// <summary>
        /// Checks if this source can execute a given interaction
        /// </summary>
        /// <param name="interaction">The interaction to check</param>
        /// <returns>If this interaction source can execute the interaction</returns>
        bool CanExecuteInteraction(IInteraction interaction);

        /// <summary>
        /// Executes the interaction (server-side)
        /// </summary>
        /// <param name="interactionEvent">The interaction event</param>
        /// <param name="interaction">The desired interaction</param>
        /// <returns>A reference to the interaction</returns>
        InteractionReference Interact(InteractionEvent interactionEvent, IInteraction interaction);

        /// <summary>
        /// Executes the interaction (client-side)
        /// </summary>
        /// <param name="interactionEvent">The interaction event</param>
        /// <param name="interaction">The desired interaction</param>
        /// <param name="reference">The reference to the interaction (generated on server)</param>
        void ClientInteract(InteractionEvent interactionEvent, IInteraction interaction, InteractionReference reference);
        /// <summary>
        /// Cancels an interaction
        /// </summary>
        /// <param name="reference">The reference to the interaction</param>
        void CancelInteraction(InteractionReference reference);
    }
}