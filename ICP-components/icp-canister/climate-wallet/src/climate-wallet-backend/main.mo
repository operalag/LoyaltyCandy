import Nat32 "mo:base/Nat32";
actor Counter {

  var count : Nat32 = 0;

  public shared func inc() : async () { count += 1 };

  public shared func read() : async Nat32 { count };

  public shared func bump() : async Nat32 {
    count += 1;
    count;
  };

  public shared func set(value : Nat32) : async Nat32 {
    count := value;
    count;
  };
};
