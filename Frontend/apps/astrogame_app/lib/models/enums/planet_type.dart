import 'package:json_annotation/json_annotation.dart';

enum PlanetType {
  @JsonValue(0)
  volcano,

  @JsonValue(1)
  desert,

  @JsonValue(2)
  continental,

  @JsonValue(3)
  ocean,

  @JsonValue(4)
  rock,

  @JsonValue(5)
  gas,

  @JsonValue(6)
  ice,

  @JsonValue(7)
  gaia,
}

const Map<PlanetType, String> PlanetTypeName = {
  PlanetType.volcano: 'Volcano',
  PlanetType.desert: 'Desert',
  PlanetType.continental: 'Continental',
  PlanetType.ocean: 'Ocean',
  PlanetType.rock: 'Rock',
  PlanetType.gas: 'Gas',
  PlanetType.ice: 'Ice',
  PlanetType.gaia: 'Gaia',
};
