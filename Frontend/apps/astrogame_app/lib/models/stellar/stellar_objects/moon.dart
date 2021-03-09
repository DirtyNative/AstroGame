import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'moon.g.dart';

@GuidConverter()
@JsonSerializable()
class Moon extends StellarObject {
  @JsonKey()
  double scale;

  @JsonKey()
  double axialTilt;

  @JsonKey()
  List<StellarObjectResource> resources;

  @JsonKey()
  int order;

  Moon(
    Guid id,
    String name,
    StellarSystem parentSystem,
    Guid parentSystemId,
    double averageDistanceToCenter,
    double rotationSpeed,
    int averageTemperature,
    String assetName,
    this.scale,
    this.axialTilt,
    this.resources,
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

  factory Moon.fromJson(Map<String, dynamic> json) => _$MoonFromJson(json);
  Map<String, dynamic> toJson() => _$MoonToJson(this);
}
