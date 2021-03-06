import 'package:json_annotation/json_annotation.dart';

part 'planet_instantiation.g.dart';

@JsonSerializable()
class PlanetInstantiation {
  String planetPrefabName;
  String atmospherePrefabName;
  String ringPrefabName;
  String cloudsPrefabName;

  PlanetInstantiation(this.planetPrefabName, this.atmospherePrefabName,
      this.ringPrefabName, this.cloudsPrefabName);

  factory PlanetInstantiation.fromJson(Map<String, dynamic> json) =>
      _$PlanetInstantiationFromJson(json);
  Map<String, dynamic> toJson() => _$PlanetInstantiationToJson(this);
}
