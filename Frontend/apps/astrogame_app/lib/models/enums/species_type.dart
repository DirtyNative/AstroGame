import 'package:json_annotation/json_annotation.dart';

enum SpeciesType {
  @JsonValue(0)
  lithoid,

  @JsonValue(1)
  humanoid,

  @JsonValue(2)
  arthropoid,

  @JsonValue(3)
  swarm,

  @JsonValue(4)
  avian,

  @JsonValue(5)
  mammalian,

  @JsonValue(6)
  molluscoid,

  @JsonValue(7)
  necroid,

  @JsonValue(8)
  plantoid,

  @JsonValue(9)
  reptilian,

  @JsonValue(10)
  synthetic,

  @JsonValue(11)
  fungoid,
}
