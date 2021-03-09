import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet_type.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'planet.g.dart';

@GuidConverter()
@JsonSerializable()
class Planet extends StellarObject {
  @JsonKey()
  PlanetType planetType;

  @JsonKey()
  double scale;

  @JsonKey()
  double axialTilt;

  @JsonKey()
  List<StellarObjectResource> resources;

  @JsonKey()
  bool hasHabitableAtmosphere;

  @JsonKey()
  int order;

  Planet(
    Guid id,
    String name,
    StellarSystem parentSystem,
    Guid parentSystemId,
    double averageDistanceToCenter,
    double rotationSpeed,
    int averageTemperature,
    String assetName,
    this.planetType,
    this.scale,
    this.axialTilt,
    this.resources,
    this.hasHabitableAtmosphere,
    this.order,
  ) : super(
          id,
          name,
          parentSystem,
          parentSystemId,
          averageDistanceToCenter,
          rotationSpeed,
          averageTemperature,
          assetName,
        );

  factory Planet.fromJson(Map<String, dynamic> json) => _$PlanetFromJson(json);
  Map<String, dynamic> toJson() => _$PlanetToJson(this);
}
