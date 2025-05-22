interface HostObjectsSyncRoot {
	Bridge: BrowsingContextBridge;
}

interface BrowsingContextBridge extends HostObjectSyncProxy {
	[key: string]: unknown;

	OnDOMContentLoaded(): void;

	GetEnumerator(): RequestEnumerator;
}

interface RequestEnumerator {
	[key: string]: unknown;

	MoveNext(): boolean;
	readonly Current: ItemItemItem;
	Dispose(): void;
}

interface ItemItemItem {
	readonly Request: string;
	Return(value: string | undefined): void;
	Throw(value: string): void;
}

type BridgeRequestGetter = {
	readonly Type: "getter";
	readonly RefId: number;
	readonly Property: string;
}

type BridgeRequestSetter = {
	readonly Type: "setter";
	readonly RefId: number;
	readonly Property: string;
	readonly Value: string;
}

type BridgeRequestInvoke = {
	readonly Type: "invoke";
	readonly RefId: number;
	readonly Method: string;
	readonly Args: any[];
}

type BridgeRequest =
	BridgeRequestGetter
	| BridgeRequestSetter
	| BridgeRequestInvoke
	;
