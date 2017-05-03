using System;
using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMessenger : PersistentSingleton<EventMessenger> {
    private static Dictionary<string, Delegate> eventHandlers = new Dictionary<string, Delegate>();

    protected override void Awake() {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public static void StartListening(string eventName, Action handler) {
        ComposeDictionary(eventName);
        if(CheckHandler(eventName, handler)) { 
            eventHandlers[eventName] = (eventHandlers[eventName] as Action) + handler;
        }
    }

    public static void StartListening<T>(string eventName, Action<T> handler) {
        ComposeDictionary(eventName);
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T>) + handler;
        }
    }

    public static void StartListening<T, U>(string eventName, Action<T, U> handler) {
        ComposeDictionary(eventName);
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T, U>) + handler;
        }
    }

    public static void StartListening<T, U, V>(string eventName, Action<T, U, V> handler) {
        ComposeDictionary(eventName);
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T, U, V>) + handler;
        }
    }

    public static void StopListening(string eventName, Action handler) {
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action) - handler;
        }
        FinishRemove(eventName);
    }

    public static void StopListening<T>(string eventName, Action<T> handler) {
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T>) - handler;
        }
        FinishRemove(eventName);
    }

    public static void StopListening<T, U>(string eventName, Action<T, U> handler) {
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T, U>) - handler;
        }
        FinishRemove(eventName);
    }

    public static void StopListening<T, U, V>(string eventName, Action<T, U, V> handler) {
        if (CheckHandler(eventName, handler)) {
            eventHandlers[eventName] = (eventHandlers[eventName] as Action<T, U, V>) - handler;
        }
        FinishRemove(eventName);
    }

    public static void TriggerEvent(string eventName) {
        if(CheckEvent(eventName)) {
            Action handlers = eventHandlers[eventName] as Action;
            if (handlers != null) {
                handlers();
            } else {
                PrintError(string.Format("Mismatch in event handler and trigger signatures for event {0}", eventName));
            }
        }
    }

    private static void ComposeDictionary(string eventName) {
        if (!eventHandlers.ContainsKey(eventName)) {
            eventHandlers.Add(eventName, null);
        }
    }

    private static void FinishRemove(string eventName) {
        if (eventHandlers[eventName] == null) {
            eventHandlers.Remove(eventName);
        }
    }

    private static bool CheckHandler(string eventName, Delegate handler) {
        var current = eventHandlers[eventName];
        if (current != null && current.GetType() != handler.GetType()) {
            PrintError(string.Format("Invalid event handler signature for event {0}. Expected {1} but got {2}", 
                eventName, current.GetType().Name, handler.GetType().Name));
            return false;
        }
        return true;
    }


    private static bool CheckEvent(string eventName) {
        if(!eventHandlers.ContainsKey(eventName)) {
            PrintError(string.Format("No handlers found for event {0}", eventName));
            return false;
        }
        return true;
    }
    private static void Cleanup() {
        foreach (var entry in eventHandlers.Where(kv => kv.Value == null).ToList()) {
            eventHandlers.Remove(entry.Key);
        }
    }

    private static void PrintError(string message) {
        Debug.Log(string.Format("{0}: {1}", typeof(EventMessenger).Name, message));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode) {
        Cleanup();
    }
}
