import 'package:json_annotation/json_annotation.dart';

enum StellarObjectType {
  @JsonValue(0)
  star,

  @JsonValue(1)
  blackHole,

  @JsonValue(2)
  planet,

  @JsonValue(3)
  moon,

  @JsonValue(4)
  asteroid,

  @JsonValue(5)
  asteroidBelt,
}
